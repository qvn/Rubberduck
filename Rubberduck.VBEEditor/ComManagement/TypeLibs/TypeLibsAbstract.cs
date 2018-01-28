﻿using System;
using System.Runtime.InteropServices;
using ComTypes = System.Runtime.InteropServices.ComTypes;

namespace Rubberduck.VBEditor.ComManagement.TypeLibsAbstract
{
    /// <summary>
    /// Windows API structure used by VirtualQuery, see https://msdn.microsoft.com/en-us/library/windows/desktop/aa366775.aspx
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct MEMORY_BASIC_INFORMATION
    {
        public IntPtr BaseAddress;
        public IntPtr AllocationBase;
        public uint AllocationProtect;
        public IntPtr RegionSize;
        public uint State;
        public ALLOCATION_PROTECTION Protect;
        public uint Type;
    }

    /// <summary>
    /// Windows API constants used by VirtualQuery, see https://msdn.microsoft.com/en-us/library/windows/desktop/aa366786.aspx
    /// </summary>
    public enum ALLOCATION_PROTECTION : uint
    {
        PAGE_EXECUTE = 0x00000010,
        PAGE_EXECUTE_READ = 0x00000020,
        PAGE_EXECUTE_READWRITE = 0x00000040,
        PAGE_EXECUTE_WRITECOPY = 0x00000080,
        PAGE_NOACCESS = 0x00000001,
        PAGE_READONLY = 0x00000002,
        PAGE_READWRITE = 0x00000004,
        PAGE_WRITECOPY = 0x00000008,
        PAGE_GUARD = 0x00000100,
        PAGE_NOCACHE = 0x00000200,
        PAGE_WRITECOMBINE = 0x00000400
    }

    /// <summary>
    /// A version of IDispatch that allows us to call its members explicitly
    /// see https://msdn.microsoft.com/en-us/library/windows/desktop/ms221608(v=vs.85).aspx
    /// </summary>
    [ComImport(), Guid("00020400-0000-0000-C000-000000000046")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IDispatch
    {
        [PreserveSig] int GetTypeInfoCount([Out] out uint pctinfo);
        [PreserveSig] int GetTypeInfo([In] uint iTInfo, [In] uint lcid, [Out] out ComTypes.ITypeInfo pTypeInfo);
        [PreserveSig] int GetIDsOfNames([In] ref Guid riid, [In] string[] rgszNames, [In] uint cNames, [In] uint lcid, [Out] out int[] rgDispId);

        [PreserveSig]
        int Invoke([In] int dispIdMember,
            [In] ref Guid riid,
            [In] uint lcid,
            [In] uint dwFlags,
            [In, Out] ref ComTypes.DISPPARAMS pDispParams,
            [Out] out Object pVarResult,
            [In, Out] ref ComTypes.EXCEPINFO pExcepInfo,
            [Out] out uint pArgErr);
    }

    public static class ComHelper
    {
        /// <summary>
        /// Equivalent of the Windows FAILED() macro in C
        /// see https://msdn.microsoft.com/en-us/library/windows/desktop/ms693474(v=vs.85).aspx
        /// </summary>
        /// <param name="hr">HRESULT from a COM API call</param>
        /// <returns>true if the HRESULT indicated failure</returns>
        public static bool HRESULT_FAILED(int hr) => hr < 0;
    }

    public static class IDispatchHelper
    {
        static Guid GUID_NULL = new Guid();

        /// <summary>
        /// IDispatch::Invoke flags
        /// see https://msdn.microsoft.com/en-gb/library/windows/desktop/ms221479(v=vs.85).aspx
        /// </summary>
        public enum InvokeKind : int
        {
            DISPATCH_METHOD = 1,
            DISPATCH_PROPERTYGET = 2,
            DISPATCH_PROPERTYPUT = 4,
            DISPATCH_PROPERTYPUTREF = 8,
        }

        /// <summary>
        /// Simplified equivalent of VARIANT structure often used in COM
        /// see https://msdn.microsoft.com/en-us/library/windows/desktop/ms221627(v=vs.85).aspx
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct VARIANT
        {
            short vt;
            short reserved1;
            short reserved2;
            short reserved3;
            IntPtr data1;
            IntPtr data2;
        }

        /// <summary>
        /// Convert input args into a contigious array of real COM VARIANTs for the DISPPARAMS struct used by IDispatch::Invoke
        /// see https://msdn.microsoft.com/en-us/library/windows/desktop/ms221416(v=vs.85).aspx
        /// </summary>
        /// <param name="args">An array of arguments to wrap</param>
        /// <returns>DISPPARAMS structure ready to pass to IDispatch::Invoke</returns>
        private static ComTypes.DISPPARAMS PrepareDispatchArgs(object[] args)
        {
            var pDispParams = new ComTypes.DISPPARAMS();

            if ((args != null) && (args.Length != 0))
            {
                var variantStructSize = Marshal.SizeOf(typeof(VARIANT));
                pDispParams.cArgs = args.Length;

                var argsVariantLength = variantStructSize * pDispParams.cArgs;
                var variantArgsArray = Marshal.AllocHGlobal(argsVariantLength);

                // In IDispatch::Invoke, arguments are passed in reverse order
                IntPtr variantArgsArrayOffset = variantArgsArray + argsVariantLength;
                foreach (var arg in args)
                {
                    variantArgsArrayOffset -= variantStructSize;
                    Marshal.GetNativeVariantForObject(arg, variantArgsArrayOffset);
                }
                pDispParams.rgvarg = variantArgsArray;
            }
            return pDispParams;
        }

        [DllImport("oleaut32.dll", SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        static extern Int32 VariantClear(IntPtr pvarg);

        /// <summary>
        /// frees all unmanaged memory assoicated with a DISPPARAMS structure
        /// see https://msdn.microsoft.com/en-us/library/windows/desktop/ms221416(v=vs.85).aspx
        /// </summary>
        /// <param name="pDispParams"></param>
        private static void UnprepareDispatchArgs(ComTypes.DISPPARAMS pDispParams)
        {
            if (pDispParams.rgvarg != IntPtr.Zero)
            {
                // free the array of COM VARIANTs
                var variantStructSize = Marshal.SizeOf(typeof(VARIANT));
                var variantArgsArrayOffset = pDispParams.rgvarg;
                int argIndex = 0;
                while (argIndex < pDispParams.cArgs)
                {
                    VariantClear(variantArgsArrayOffset);
                    variantArgsArrayOffset += variantStructSize;
                    argIndex++;
                }
                Marshal.FreeHGlobal(pDispParams.rgvarg);
            }
        }

        /// <summary>
        /// A basic helper for IDispatch::Invoke
        /// </summary>
        /// <param name="obj">The IDispatch object of which you want to invoke a member on</param>
        /// <param name="memberId">The dispatch ID of the member to invoke</param>
        /// <param name="invokeKind">See InvokeKind enumeration</param>
        /// <param name="args">Array of arguments to pass to the call, or null for no args</param>
        /// <remarks>TODO support DISPATCH_PROPERTYPUTREF (property-set) which requires special handling</remarks>
        /// <returns>An object representing the return value from the called routine</returns>
        public static object Invoke(IDispatch obj, int memberId, InvokeKind invokeKind, object[] args = null)
        {
            var pDispParams = PrepareDispatchArgs(args);
            var pExcepInfo = new ComTypes.EXCEPINFO();
            
            int hr = obj.Invoke(memberId, ref GUID_NULL, 0, (uint)invokeKind,
                                    ref pDispParams, out object pVarResult, ref pExcepInfo, out uint pErrArg);

            UnprepareDispatchArgs(pDispParams);

            if (ComHelper.HRESULT_FAILED(hr))
            {
                if ((hr == (int)KnownComHResults.DISP_E_EXCEPTION) && (ComHelper.HRESULT_FAILED(pExcepInfo.scode)))
                {
                    throw Marshal.GetExceptionForHR(pExcepInfo.scode);
                }
                throw Marshal.GetExceptionForHR(hr);
            }

            return pVarResult;
        }
    }

    /// <summary>
    /// A compatible version of ITypeInfo, where COM objects are outputted as IntPtrs instead of objects
    /// see https://msdn.microsoft.com/en-gb/library/windows/desktop/ms221696(v=vs.85).aspx
    /// </summary>
    [ComImport(), Guid("00020401-0000-0000-C000-000000000046")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ITypeInfo_Ptrs
    {
        void GetTypeAttr(out IntPtr ppTypeAttr);
        void GetTypeComp(out IntPtr ppTComp);
        void GetFuncDesc(int index, out IntPtr ppFuncDesc);
        void GetVarDesc(int index, out IntPtr ppVarDesc);
        void GetNames(int memid, [Out] out string rgBstrNames, int cMaxNames, out int pcNames);
        void GetRefTypeOfImplType(int index, out int href);
        void GetImplTypeFlags(int index, out ComTypes.IMPLTYPEFLAGS pImplTypeFlags);
        void GetIDsOfNames(string[] rgszNames, int cNames, int[] pMemId);
        void Invoke(object pvInstance, int memid, short wFlags, ref ComTypes.DISPPARAMS pDispParams, IntPtr pVarResult, IntPtr pExcepInfo, out int puArgErr);
        void GetDocumentation(int index, out string strName, out string strDocString, out int dwHelpContext, out string strHelpFile);
        void GetDllEntry(int memid, ComTypes.INVOKEKIND invKind, IntPtr pBstrDllName, IntPtr pBstrName, IntPtr pwOrdinal);
        void GetRefTypeInfo(int hRef, out IntPtr ppTI);
        void AddressOfMember(int memid, ComTypes.INVOKEKIND invKind, out IntPtr ppv);
        void CreateInstance(object pUnkOuter, ref Guid riid, out object ppvObj);
        void GetMops(int memid, out string pBstrMops);
        void GetContainingTypeLib(out IntPtr ppTLB, out int pIndex);
        void ReleaseTypeAttr(IntPtr pTypeAttr);
        void ReleaseFuncDesc(IntPtr pFuncDesc);
        void ReleaseVarDesc(IntPtr pVarDesc);
    }

    /// <summary>
    /// An internal interface exposed by VBA for all components (modules, class modules, etc)
    /// </summary>
    /// <remarks>This internal interface is known to be supported since the very earliest version of VBA6</remarks>
    [ComImport(), Guid("DDD557E1-D96F-11CD-9570-00AA0051E5D4")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IVBEComponent
    {
        void Placeholder1();
        void Placeholder2();
        void Placeholder3();
        void Placeholder4();
        void Placeholder5();
        void Placeholder6();
        void Placeholder7();
        void Placeholder8();
        void Placeholder9();
        void Placeholder10();
        void Placeholder11();
        void Placeholder12();
        void CompileComponent();
        void Placeholder14();
        void Placeholder15();
        void Placeholder16();
        void Placeholder17();
        void Placeholder18();
        void Placeholder19();
        void Placeholder20();
        void Placeholder21();
        void Placeholder22();
        void Placeholder23();
        void Placeholder24();
        void Placeholder25();
        void Placeholder26();
        void Placeholder27();
        void Placeholder28();
        void Placeholder29();
        void Placeholder30();
        void Placeholder31();
        void Placeholder32();
        void Placeholder33();
        void GetSomeRelatedTypeInfoPtrs(out IntPtr A, out IntPtr B);        // returns 2 TypeInfos, seemingly related to this ITypeInfo, but slightly different.
    }
    
    /// <summary>
    /// An extended version of ITypeInfo, hosted by the VBE that includes a particularly helpful member, GetStdModAccessor
    /// see https://msdn.microsoft.com/en-gb/library/windows/desktop/ms221696(v=vs.85).aspx
    /// </summary>
    /// <remarks>This extended interface is known to be supported since the very earliest version of VBA6</remarks>
    [ComImport(), Guid("CACC1E82-622B-11D2-AA78-00C04F9901D2")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IVBETypeInfo
    {
        void GetTypeAttr(out IntPtr ppTypeAttr);
        void GetTypeComp(out IntPtr ppTComp);
        void GetFuncDesc(int index, out IntPtr ppFuncDesc);
        void GetVarDesc(int index, out IntPtr ppVarDesc);
        void GetNames(int memid, [Out] out string rgBstrNames, int cMaxNames, out int pcNames);
        void GetRefTypeOfImplType(int index, out int href);
        void GetImplTypeFlags(int index, out ComTypes.IMPLTYPEFLAGS pImplTypeFlags);
        void GetIDsOfNames(string[] rgszNames, int cNames, int[] pMemId);
        void Invoke(object pvInstance, int memid, short wFlags, ref ComTypes.DISPPARAMS pDispParams, IntPtr pVarResult, IntPtr pExcepInfo, out int puArgErr);
        void GetDocumentation(int index, out string strName, out string strDocString, out int dwHelpContext, out string strHelpFile);
        void GetDllEntry(int memid, ComTypes.INVOKEKIND invKind, IntPtr pBstrDllName, IntPtr pBstrName, IntPtr pwOrdinal);
        void GetRefTypeInfo(int hRef, out IntPtr ppTI);
        void AddressOfMember(int memid, ComTypes.INVOKEKIND invKind, out IntPtr ppv);
        void CreateInstance(object pUnkOuter, ref Guid riid, out object ppvObj);
        void GetMops(int memid, out string pBstrMops);
        void GetContainingTypeLib(out IntPtr ppTLB, out int pIndex);
        void ReleaseTypeAttr(IntPtr pTypeAttr);
        void ReleaseFuncDesc(IntPtr pFuncDesc);
        void ReleaseVarDesc(IntPtr pVarDesc);

        void Placeholder1();
        IDispatch GetStdModAccessor();            // a handy extra vtable entry we can use to invoke members in standard modules.
    }

    /// <summary>
    /// A compatible version of ITypeLib, where COM objects are outputted as IntPtrs instead of objects
    /// see https://msdn.microsoft.com/en-us/library/windows/desktop/ms221549(v=vs.85).aspx
    /// </summary>
    [ComImport(), Guid("00020402-0000-0000-C000-000000000046")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ITypeLib_Ptrs
    {
        int GetTypeInfoCount();
        void GetTypeInfo(int index, out IntPtr ppTI);
        void GetTypeInfoType(int index, out ComTypes.TYPEKIND pTKind);
        void GetTypeInfoOfGuid(ref Guid guid, out IntPtr ppTInfo);
        void GetLibAttr(out IntPtr ppTLibAttr);
        void GetTypeComp(out IntPtr ppTComp);
        void GetDocumentation(int index, out string strName, out string strDocString, out int dwHelpContext, out string strHelpFile);
        bool IsName(string szNameBuf, int lHashVal);
        void FindName(string szNameBuf, int lHashVal, IntPtr[] ppTInfo, int[] rgMemId, ref short pcFound);
        void ReleaseTLibAttr(IntPtr pTLibAttr);
    }

    /// <summary>
    /// An internal representation of the VBE References collection object, as returned from VBE.ActiveVBProject.References, or similar
    /// These offsets are known to be valid across 32-bit and 64-bit versions of VBA and VB6, right back from when VBA6 was first released.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    struct VBEReferencesObj
    {
        IntPtr vTable1;     // _References vtable
        IntPtr vTable2;
        IntPtr vTable3;
        IntPtr Object1;
        IntPtr Object2;
        public IntPtr TypeLib;
        IntPtr Placeholder1;
        IntPtr Placeholder2;
        IntPtr RefCount;
    }
    
    /// <summary>
    /// An internal representation of the ITypeLib object hosted by the VBE.
    /// Also provides Prev/Next pointers, exposing a double linked list of all loaded project ITypeLibs
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    struct VBETypeLibObj
    {
        IntPtr vTable1;     // ITypeLib vtable
        IntPtr vTable2;
        IntPtr vTable3;
        public IntPtr Prev;
        public IntPtr Next;
    }

    /// <summary>
    /// An internal interface supported by VBA for all projects. Obtainable from a VBE hosted ITypeLib 
    /// in order to access a few extra features...
    /// </summary>
    /// <remarks>This internal interface is known to be supported since the very earliest version of VBA6</remarks>
    [ComImport(), Guid("DDD557E0-D96F-11CD-9570-00AA0051E5D4")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    interface IVBEProject
    {
        string GetProjectName();                 // same as calling ITypeLib::GetDocumentation(-1)                   
        void SetProjectName(string value);       // same as IVBEProject2::set_ProjectName()
        int GetVbeLCID();
        void Placeholder3();                      // calls IVBEProject2::Placeholder8
        void Placeholder4();                      
        void Placeholder5();                    
        void Placeholder6();
        void Placeholder7();
        string GetConditionalCompilationArgs();
        void SetConditionalCompilationArgs(string args);
        void Placeholder8();
        void Placeholder9();
        void Placeholder10();
        void Placeholder11();
        void Placeholder12();
        void Placeholder13();
        int GetReferencesCount();
        IntPtr GetReferenceTypeLib(int ReferenceIndex);
        void Placeholder16();
        void Placeholder17();
        string GetReferenceString(int ReferenceIndex); // the raw reference string
        void CompileProject();                            // throws COM exception 0x800A9C64 if error occurred during compile.
    }

    /*
     Not currently used.
    // IVBEProject2, vtable position just before the IVBEProject, not queryable, so needs aggregation
    [ComImport(), Guid("FFFFFFFF-0000-0000-C000-000000000046")]  // 
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    interface IVBEProject2
    {
        void Placeholder1();                    // returns E_NOTIMPL
        void SetProjectName(string value);
        void SetProjectVersion(ushort wMajorVerNum, ushort wMinorVerNum);
        void SetProjectGUID(ref Guid value);
        void SetProjectDescription(string value);
        void SetProjectHelpFileName(string value);
        void SetProjectHelpContext(int value);
    }
    */

    /// <summary>
    /// An extended version of TYPEKIND, which VBA uses internally to identify VBA classes as a seperate type
    /// see https://msdn.microsoft.com/en-us/library/windows/desktop/ms221643(v=vs.85).aspx
    /// </summary>
    public enum TYPEKIND_VBE
    {
        TKIND_ENUM = 0,
        TKIND_RECORD = 1,
        TKIND_MODULE = 2,
        TKIND_INTERFACE = 3,
        TKIND_DISPATCH = 4,
        TKIND_COCLASS = 5,
        TKIND_ALIAS = 6,
        TKIND_UNION = 7,

        TKIND_VBACLASS = 8,               
    }

    /// <summary>
    /// Used by methods in the ITypeInfo and ITypeLib interfaces.  Usually used to get the root type or library name.
    /// </summary>
    public enum TypeLibConsts : int
    {
        MEMBERID_NIL = -1,
    }

    /// <summary>
    /// Some known COM HRESULTs used in our code
    /// </summary>
    public enum KnownComHResults : int
    {
        E_VBA_COMPILEERROR = unchecked((int)0x800A9C64),
        E_NOTIMPL = unchecked((int)0x80004001),
        DISP_E_EXCEPTION = unchecked((int)0x80020009),
    }
}
