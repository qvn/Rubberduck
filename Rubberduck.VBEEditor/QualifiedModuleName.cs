using System.Globalization;
using Rubberduck.VBEditor.SafeComWrappers;
using Rubberduck.VBEditor.SafeComWrappers.Abstract;

namespace Rubberduck.VBEditor
{
    /// <summary>
    /// Represents a VBComponent or a VBProject.
    /// </summary>
    public readonly struct QualifiedModuleName
    {
        public static string GetProjectId(IVBProject project)
        {
            if (project.IsWrappingNullReference)
            {
                return string.Empty;
            }

            var projectId = project.ProjectId;

            if (string.IsNullOrEmpty(projectId))
            {
                project.AssignProjectId();
                projectId = project.ProjectId;
            }

            return projectId;
        }

        /// <summary>
        /// Gets the standard projectId for a library reference.
        /// Do not use this overload for referenced user projects.
        /// </summary>
        public static string GetProjectId(ReferenceInfo reference)
        {
            return new QualifiedModuleName(reference).ProjectId;
        }

        public static int GetContentHash(IVBComponent component)
        {
            return component?.ContentHash() ?? 0;
        }

        public QualifiedModuleName(IVBProject project)
        {
            _componentName = null;
            ComponentType = ComponentType.Undefined;
            _projectName = project.Name;
            ProjectPath = string.Empty;
            ProjectId = GetProjectId(project);
            ModuleContentHashOnCreation = GetContentHash(null);
        }

        public QualifiedModuleName(IVBComponent component)
        {
            ComponentType = component.Type;
            _componentName = component.IsWrappingNullReference ? string.Empty : component.Name;

            //note: We set this property in order to stabelize the component.
            //For some reason, components sometimes seem to get removed on the COM side although 
            //an RCW is still holding a reference. For some reason, opening the CodeModule of a 
            //component seems to prevent this. 
            //This is a hack to open the code module on each component for which we get a QMN 
            //in a way that does not get optimized away.
            ModuleContentHashOnCreation = GetContentHash(component);

            using (var components = component.Collection)
            {
                using (var project = components.Parent)
                {
                    _projectName = project == null ? string.Empty : project.Name;
                    ProjectPath = string.Empty;
                    ProjectId = GetProjectId(project);
                }
            }
        }

        /// <summary>
        /// Creates a QualifiedModuleName for a library reference.
        /// Do not use this overload for referenced user projects.
        /// </summary>
        public QualifiedModuleName(ReferenceInfo reference)
        :this(reference.Name,
            reference.FullPath,
            reference.Name)
        {}

        /// <summary>
        /// Creates a QualifiedModuleName for a built-in declaration.
        /// Do not use this overload for user declarations.
        /// </summary>
        public QualifiedModuleName(string projectName, string projectPath, string componentName)
        {
            _projectName = projectName;
            ProjectPath = projectPath;
            ProjectId = "External" + $"{_projectName};{ProjectPath}".GetHashCode().ToString(CultureInfo.InvariantCulture);
            _componentName = componentName;
            ComponentType = ComponentType.ComComponent;
            ModuleContentHashOnCreation = GetContentHash(null);
        }

        public QualifiedMemberName QualifyMemberName(string member)
        {
            return new QualifiedMemberName(this, member);
        }

        public ComponentType ComponentType { get; }

        public bool IsParsable => ComponentType != ComponentType.ResFile && ComponentType != ComponentType.RelatedDocument;
        public string ProjectId { get; }

        private readonly string _componentName;
        public string ComponentName => _componentName ?? string.Empty;

        public string Name => ToString();

        private readonly string _projectName;
        public string ProjectName => _projectName ?? string.Empty;

        public string ProjectPath { get; }
        public int ModuleContentHashOnCreation { get; }

        public override string ToString()
        {
            return string.IsNullOrEmpty(_componentName) && string.IsNullOrEmpty(_projectName)
                ? string.Empty
                : (string.IsNullOrEmpty(ProjectPath) ? string.Empty : System.IO.Path.GetFileName(ProjectPath) + ";")
                     + $"{_projectName}.{_componentName}";
        }

        public override int GetHashCode()
        {
            return HashCode.Compute(ProjectId ?? string.Empty, _componentName ?? string.Empty);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            var other = obj as QualifiedModuleName?;

            if (other == null)
            {
                return false;
            }

            return other.Value.ProjectId == ProjectId && other.Value.ComponentName == ComponentName;
        }

        public static bool operator ==(QualifiedModuleName a, QualifiedModuleName b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(QualifiedModuleName a, QualifiedModuleName b)
        {
            return !a.Equals(b);
        }
    }
}
