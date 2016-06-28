//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.3
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from C:\Users\hosch\Documents\Visual Studio 2015\Projects\Rubberduck\Rubberduck.Parsing\Preprocessing\VBADate.g4 by ANTLR 4.3

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591

namespace Rubberduck.Parsing {
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using System.Collections.Generic;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.3")]
[System.CLSCompliant(false)]
public partial class VBADateParser : Parser {
	public const int
		AMPM=1, LINE_CONTINUATION=2, JANUARY=3, FEBRUARY=4, MARCH=5, APRIL=6, 
		MAY=7, JUNE=8, JULY=9, AUGUST=10, SEPTEMBER=11, OCTOBER=12, NOVEMBER=13, 
		DECEMBER=14, JAN=15, FEB=16, MAR=17, APR=18, JUN=19, JUL=20, AUG=21, SEP=22, 
		OCT=23, NOV=24, DEC=25, AM=26, PM=27, HASH=28, COMMA=29, DASH=30, SLASH=31, 
		COLON=32, DOT=33, WS=34, DIGIT=35;
	public static readonly string[] tokenNames = {
		"<INVALID>", "AMPM", "LINE_CONTINUATION", "JANUARY", "FEBRUARY", "MARCH", 
		"APRIL", "MAY", "JUNE", "JULY", "AUGUST", "SEPTEMBER", "OCTOBER", "NOVEMBER", 
		"DECEMBER", "JAN", "FEB", "MAR", "APR", "JUN", "JUL", "AUG", "SEP", "OCT", 
		"NOV", "DEC", "AM", "PM", "'#'", "','", "'-'", "'/'", "':'", "'.'", "WS", 
		"DIGIT"
	};
	public const int
		RULE_compilationUnit = 0, RULE_dateLiteral = 1, RULE_dateOrTime = 2, RULE_dateValue = 3, 
		RULE_dateValuePart = 4, RULE_dateValueNumber = 5, RULE_dateSeparator = 6, 
		RULE_monthName = 7, RULE_englishMonthName = 8, RULE_englishMonthAbbreviation = 9, 
		RULE_timeValue = 10, RULE_timeValuePart = 11, RULE_timeSeparator = 12;
	public static readonly string[] ruleNames = {
		"compilationUnit", "dateLiteral", "dateOrTime", "dateValue", "dateValuePart", 
		"dateValueNumber", "dateSeparator", "monthName", "englishMonthName", "englishMonthAbbreviation", 
		"timeValue", "timeValuePart", "timeSeparator"
	};

	public override string GrammarFileName { get { return "VBADate.g4"; } }

	public override string[] TokenNames { get { return tokenNames; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string SerializedAtn { get { return _serializedATN; } }

	public VBADateParser(ITokenStream input)
		: base(input)
	{
		_interp = new ParserATNSimulator(this,_ATN);
	}
	public partial class CompilationUnitContext : ParserRuleContext {
		public ITerminalNode Eof() { return GetToken(VBADateParser.Eof, 0); }
		public DateLiteralContext dateLiteral() {
			return GetRuleContext<DateLiteralContext>(0);
		}
		public CompilationUnitContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_compilationUnit; } }
		public override void EnterRule(IParseTreeListener listener) {
			IVBADateListener typedListener = listener as IVBADateListener;
			if (typedListener != null) typedListener.EnterCompilationUnit(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IVBADateListener typedListener = listener as IVBADateListener;
			if (typedListener != null) typedListener.ExitCompilationUnit(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IVBADateVisitor<TResult> typedVisitor = visitor as IVBADateVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitCompilationUnit(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public CompilationUnitContext compilationUnit() {
		CompilationUnitContext _localctx = new CompilationUnitContext(_ctx, State);
		EnterRule(_localctx, 0, RULE_compilationUnit);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 26; dateLiteral();
			State = 27; Match(Eof);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.ReportError(this, re);
			_errHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class DateLiteralContext : ParserRuleContext {
		public ITerminalNode WS(int i) {
			return GetToken(VBADateParser.WS, i);
		}
		public DateOrTimeContext dateOrTime() {
			return GetRuleContext<DateOrTimeContext>(0);
		}
		public IReadOnlyList<ITerminalNode> WS() { return GetTokens(VBADateParser.WS); }
		public ITerminalNode HASH(int i) {
			return GetToken(VBADateParser.HASH, i);
		}
		public IReadOnlyList<ITerminalNode> LINE_CONTINUATION() { return GetTokens(VBADateParser.LINE_CONTINUATION); }
		public ITerminalNode LINE_CONTINUATION(int i) {
			return GetToken(VBADateParser.LINE_CONTINUATION, i);
		}
		public IReadOnlyList<ITerminalNode> HASH() { return GetTokens(VBADateParser.HASH); }
		public DateLiteralContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_dateLiteral; } }
		public override void EnterRule(IParseTreeListener listener) {
			IVBADateListener typedListener = listener as IVBADateListener;
			if (typedListener != null) typedListener.EnterDateLiteral(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IVBADateListener typedListener = listener as IVBADateListener;
			if (typedListener != null) typedListener.ExitDateLiteral(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IVBADateVisitor<TResult> typedVisitor = visitor as IVBADateVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitDateLiteral(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public DateLiteralContext dateLiteral() {
		DateLiteralContext _localctx = new DateLiteralContext(_ctx, State);
		EnterRule(_localctx, 2, RULE_dateLiteral);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 29; Match(HASH);
			State = 35;
			_la = _input.La(1);
			if (_la==LINE_CONTINUATION || _la==WS) {
				{
				State = 31;
				_errHandler.Sync(this);
				_la = _input.La(1);
				do {
					{
					{
					State = 30;
					_la = _input.La(1);
					if ( !(_la==LINE_CONTINUATION || _la==WS) ) {
					_errHandler.RecoverInline(this);
					}
					Consume();
					}
					}
					State = 33;
					_errHandler.Sync(this);
					_la = _input.La(1);
				} while ( _la==LINE_CONTINUATION || _la==WS );
				}
			}

			State = 37; dateOrTime();
			State = 38; Match(HASH);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.ReportError(this, re);
			_errHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class DateOrTimeContext : ParserRuleContext {
		public DateValueContext dateValue() {
			return GetRuleContext<DateValueContext>(0);
		}
		public ITerminalNode WS(int i) {
			return GetToken(VBADateParser.WS, i);
		}
		public IReadOnlyList<ITerminalNode> WS() { return GetTokens(VBADateParser.WS); }
		public TimeValueContext timeValue() {
			return GetRuleContext<TimeValueContext>(0);
		}
		public DateOrTimeContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_dateOrTime; } }
		public override void EnterRule(IParseTreeListener listener) {
			IVBADateListener typedListener = listener as IVBADateListener;
			if (typedListener != null) typedListener.EnterDateOrTime(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IVBADateListener typedListener = listener as IVBADateListener;
			if (typedListener != null) typedListener.ExitDateOrTime(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IVBADateVisitor<TResult> typedVisitor = visitor as IVBADateVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitDateOrTime(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public DateOrTimeContext dateOrTime() {
		DateOrTimeContext _localctx = new DateOrTimeContext(_ctx, State);
		EnterRule(_localctx, 4, RULE_dateOrTime);
		int _la;
		try {
			State = 50;
			switch ( Interpreter.AdaptivePredict(_input,3,_ctx) ) {
			case 1:
				EnterOuterAlt(_localctx, 1);
				{
				State = 40; dateValue();
				}
				break;

			case 2:
				EnterOuterAlt(_localctx, 2);
				{
				State = 41; timeValue();
				}
				break;

			case 3:
				EnterOuterAlt(_localctx, 3);
				{
				State = 42; dateValue();
				State = 44;
				_errHandler.Sync(this);
				_la = _input.La(1);
				do {
					{
					{
					State = 43; Match(WS);
					}
					}
					State = 46;
					_errHandler.Sync(this);
					_la = _input.La(1);
				} while ( _la==WS );
				State = 48; timeValue();
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.ReportError(this, re);
			_errHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class DateValueContext : ParserRuleContext {
		public IReadOnlyList<DateSeparatorContext> dateSeparator() {
			return GetRuleContexts<DateSeparatorContext>();
		}
		public IReadOnlyList<DateValuePartContext> dateValuePart() {
			return GetRuleContexts<DateValuePartContext>();
		}
		public DateSeparatorContext dateSeparator(int i) {
			return GetRuleContext<DateSeparatorContext>(i);
		}
		public DateValuePartContext dateValuePart(int i) {
			return GetRuleContext<DateValuePartContext>(i);
		}
		public DateValueContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_dateValue; } }
		public override void EnterRule(IParseTreeListener listener) {
			IVBADateListener typedListener = listener as IVBADateListener;
			if (typedListener != null) typedListener.EnterDateValue(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IVBADateListener typedListener = listener as IVBADateListener;
			if (typedListener != null) typedListener.ExitDateValue(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IVBADateVisitor<TResult> typedVisitor = visitor as IVBADateVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitDateValue(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public DateValueContext dateValue() {
		DateValueContext _localctx = new DateValueContext(_ctx, State);
		EnterRule(_localctx, 6, RULE_dateValue);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 52; dateValuePart();
			State = 53; dateSeparator();
			State = 54; dateValuePart();
			State = 58;
			switch ( Interpreter.AdaptivePredict(_input,4,_ctx) ) {
			case 1:
				{
				State = 55; dateSeparator();
				State = 56; dateValuePart();
				}
				break;
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.ReportError(this, re);
			_errHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class DateValuePartContext : ParserRuleContext {
		public DateValueNumberContext dateValueNumber() {
			return GetRuleContext<DateValueNumberContext>(0);
		}
		public MonthNameContext monthName() {
			return GetRuleContext<MonthNameContext>(0);
		}
		public DateValuePartContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_dateValuePart; } }
		public override void EnterRule(IParseTreeListener listener) {
			IVBADateListener typedListener = listener as IVBADateListener;
			if (typedListener != null) typedListener.EnterDateValuePart(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IVBADateListener typedListener = listener as IVBADateListener;
			if (typedListener != null) typedListener.ExitDateValuePart(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IVBADateVisitor<TResult> typedVisitor = visitor as IVBADateVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitDateValuePart(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public DateValuePartContext dateValuePart() {
		DateValuePartContext _localctx = new DateValuePartContext(_ctx, State);
		EnterRule(_localctx, 8, RULE_dateValuePart);
		try {
			State = 62;
			switch (_input.La(1)) {
			case DIGIT:
				EnterOuterAlt(_localctx, 1);
				{
				State = 60; dateValueNumber();
				}
				break;
			case JANUARY:
			case FEBRUARY:
			case MARCH:
			case APRIL:
			case MAY:
			case JUNE:
			case JULY:
			case AUGUST:
			case SEPTEMBER:
			case OCTOBER:
			case NOVEMBER:
			case DECEMBER:
			case JAN:
			case FEB:
			case MAR:
			case APR:
			case JUN:
			case JUL:
			case AUG:
			case SEP:
			case OCT:
			case NOV:
			case DEC:
				EnterOuterAlt(_localctx, 2);
				{
				State = 61; monthName();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.ReportError(this, re);
			_errHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class DateValueNumberContext : ParserRuleContext {
		public ITerminalNode DIGIT(int i) {
			return GetToken(VBADateParser.DIGIT, i);
		}
		public IReadOnlyList<ITerminalNode> DIGIT() { return GetTokens(VBADateParser.DIGIT); }
		public DateValueNumberContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_dateValueNumber; } }
		public override void EnterRule(IParseTreeListener listener) {
			IVBADateListener typedListener = listener as IVBADateListener;
			if (typedListener != null) typedListener.EnterDateValueNumber(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IVBADateListener typedListener = listener as IVBADateListener;
			if (typedListener != null) typedListener.ExitDateValueNumber(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IVBADateVisitor<TResult> typedVisitor = visitor as IVBADateVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitDateValueNumber(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public DateValueNumberContext dateValueNumber() {
		DateValueNumberContext _localctx = new DateValueNumberContext(_ctx, State);
		EnterRule(_localctx, 10, RULE_dateValueNumber);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 65;
			_errHandler.Sync(this);
			_la = _input.La(1);
			do {
				{
				{
				State = 64; Match(DIGIT);
				}
				}
				State = 67;
				_errHandler.Sync(this);
				_la = _input.La(1);
			} while ( _la==DIGIT );
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.ReportError(this, re);
			_errHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class DateSeparatorContext : ParserRuleContext {
		public ITerminalNode WS(int i) {
			return GetToken(VBADateParser.WS, i);
		}
		public IReadOnlyList<ITerminalNode> WS() { return GetTokens(VBADateParser.WS); }
		public ITerminalNode SLASH() { return GetToken(VBADateParser.SLASH, 0); }
		public ITerminalNode COMMA() { return GetToken(VBADateParser.COMMA, 0); }
		public ITerminalNode DASH() { return GetToken(VBADateParser.DASH, 0); }
		public DateSeparatorContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_dateSeparator; } }
		public override void EnterRule(IParseTreeListener listener) {
			IVBADateListener typedListener = listener as IVBADateListener;
			if (typedListener != null) typedListener.EnterDateSeparator(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IVBADateListener typedListener = listener as IVBADateListener;
			if (typedListener != null) typedListener.ExitDateSeparator(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IVBADateVisitor<TResult> typedVisitor = visitor as IVBADateVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitDateSeparator(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public DateSeparatorContext dateSeparator() {
		DateSeparatorContext _localctx = new DateSeparatorContext(_ctx, State);
		EnterRule(_localctx, 12, RULE_dateSeparator);
		int _la;
		try {
			State = 87;
			switch ( Interpreter.AdaptivePredict(_input,10,_ctx) ) {
			case 1:
				EnterOuterAlt(_localctx, 1);
				{
				State = 70;
				_errHandler.Sync(this);
				_la = _input.La(1);
				do {
					{
					{
					State = 69; Match(WS);
					}
					}
					State = 72;
					_errHandler.Sync(this);
					_la = _input.La(1);
				} while ( _la==WS );
				}
				break;

			case 2:
				EnterOuterAlt(_localctx, 2);
				{
				{
				State = 77;
				_errHandler.Sync(this);
				_la = _input.La(1);
				while (_la==WS) {
					{
					{
					State = 74; Match(WS);
					}
					}
					State = 79;
					_errHandler.Sync(this);
					_la = _input.La(1);
				}
				State = 80;
				_la = _input.La(1);
				if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << COMMA) | (1L << DASH) | (1L << SLASH))) != 0)) ) {
				_errHandler.RecoverInline(this);
				}
				Consume();
				State = 84;
				_errHandler.Sync(this);
				_la = _input.La(1);
				while (_la==WS) {
					{
					{
					State = 81; Match(WS);
					}
					}
					State = 86;
					_errHandler.Sync(this);
					_la = _input.La(1);
				}
				}
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.ReportError(this, re);
			_errHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class MonthNameContext : ParserRuleContext {
		public EnglishMonthAbbreviationContext englishMonthAbbreviation() {
			return GetRuleContext<EnglishMonthAbbreviationContext>(0);
		}
		public EnglishMonthNameContext englishMonthName() {
			return GetRuleContext<EnglishMonthNameContext>(0);
		}
		public MonthNameContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_monthName; } }
		public override void EnterRule(IParseTreeListener listener) {
			IVBADateListener typedListener = listener as IVBADateListener;
			if (typedListener != null) typedListener.EnterMonthName(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IVBADateListener typedListener = listener as IVBADateListener;
			if (typedListener != null) typedListener.ExitMonthName(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IVBADateVisitor<TResult> typedVisitor = visitor as IVBADateVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitMonthName(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public MonthNameContext monthName() {
		MonthNameContext _localctx = new MonthNameContext(_ctx, State);
		EnterRule(_localctx, 14, RULE_monthName);
		try {
			State = 91;
			switch (_input.La(1)) {
			case JANUARY:
			case FEBRUARY:
			case MARCH:
			case APRIL:
			case MAY:
			case JUNE:
			case JULY:
			case AUGUST:
			case SEPTEMBER:
			case OCTOBER:
			case NOVEMBER:
			case DECEMBER:
				EnterOuterAlt(_localctx, 1);
				{
				State = 89; englishMonthName();
				}
				break;
			case JAN:
			case FEB:
			case MAR:
			case APR:
			case JUN:
			case JUL:
			case AUG:
			case SEP:
			case OCT:
			case NOV:
			case DEC:
				EnterOuterAlt(_localctx, 2);
				{
				State = 90; englishMonthAbbreviation();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.ReportError(this, re);
			_errHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class EnglishMonthNameContext : ParserRuleContext {
		public ITerminalNode DECEMBER() { return GetToken(VBADateParser.DECEMBER, 0); }
		public ITerminalNode MARCH() { return GetToken(VBADateParser.MARCH, 0); }
		public ITerminalNode FEBRUARY() { return GetToken(VBADateParser.FEBRUARY, 0); }
		public ITerminalNode AUGUST() { return GetToken(VBADateParser.AUGUST, 0); }
		public ITerminalNode JULY() { return GetToken(VBADateParser.JULY, 0); }
		public ITerminalNode NOVEMBER() { return GetToken(VBADateParser.NOVEMBER, 0); }
		public ITerminalNode JUNE() { return GetToken(VBADateParser.JUNE, 0); }
		public ITerminalNode SEPTEMBER() { return GetToken(VBADateParser.SEPTEMBER, 0); }
		public ITerminalNode APRIL() { return GetToken(VBADateParser.APRIL, 0); }
		public ITerminalNode MAY() { return GetToken(VBADateParser.MAY, 0); }
		public ITerminalNode JANUARY() { return GetToken(VBADateParser.JANUARY, 0); }
		public ITerminalNode OCTOBER() { return GetToken(VBADateParser.OCTOBER, 0); }
		public EnglishMonthNameContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_englishMonthName; } }
		public override void EnterRule(IParseTreeListener listener) {
			IVBADateListener typedListener = listener as IVBADateListener;
			if (typedListener != null) typedListener.EnterEnglishMonthName(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IVBADateListener typedListener = listener as IVBADateListener;
			if (typedListener != null) typedListener.ExitEnglishMonthName(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IVBADateVisitor<TResult> typedVisitor = visitor as IVBADateVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitEnglishMonthName(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public EnglishMonthNameContext englishMonthName() {
		EnglishMonthNameContext _localctx = new EnglishMonthNameContext(_ctx, State);
		EnterRule(_localctx, 16, RULE_englishMonthName);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 93;
			_la = _input.La(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << JANUARY) | (1L << FEBRUARY) | (1L << MARCH) | (1L << APRIL) | (1L << MAY) | (1L << JUNE) | (1L << JULY) | (1L << AUGUST) | (1L << SEPTEMBER) | (1L << OCTOBER) | (1L << NOVEMBER) | (1L << DECEMBER))) != 0)) ) {
			_errHandler.RecoverInline(this);
			}
			Consume();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.ReportError(this, re);
			_errHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class EnglishMonthAbbreviationContext : ParserRuleContext {
		public ITerminalNode NOV() { return GetToken(VBADateParser.NOV, 0); }
		public ITerminalNode DEC() { return GetToken(VBADateParser.DEC, 0); }
		public ITerminalNode AUG() { return GetToken(VBADateParser.AUG, 0); }
		public ITerminalNode APR() { return GetToken(VBADateParser.APR, 0); }
		public ITerminalNode MAR() { return GetToken(VBADateParser.MAR, 0); }
		public ITerminalNode SEP() { return GetToken(VBADateParser.SEP, 0); }
		public ITerminalNode JUN() { return GetToken(VBADateParser.JUN, 0); }
		public ITerminalNode JAN() { return GetToken(VBADateParser.JAN, 0); }
		public ITerminalNode JUL() { return GetToken(VBADateParser.JUL, 0); }
		public ITerminalNode FEB() { return GetToken(VBADateParser.FEB, 0); }
		public ITerminalNode OCT() { return GetToken(VBADateParser.OCT, 0); }
		public EnglishMonthAbbreviationContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_englishMonthAbbreviation; } }
		public override void EnterRule(IParseTreeListener listener) {
			IVBADateListener typedListener = listener as IVBADateListener;
			if (typedListener != null) typedListener.EnterEnglishMonthAbbreviation(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IVBADateListener typedListener = listener as IVBADateListener;
			if (typedListener != null) typedListener.ExitEnglishMonthAbbreviation(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IVBADateVisitor<TResult> typedVisitor = visitor as IVBADateVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitEnglishMonthAbbreviation(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public EnglishMonthAbbreviationContext englishMonthAbbreviation() {
		EnglishMonthAbbreviationContext _localctx = new EnglishMonthAbbreviationContext(_ctx, State);
		EnterRule(_localctx, 18, RULE_englishMonthAbbreviation);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 95;
			_la = _input.La(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << JAN) | (1L << FEB) | (1L << MAR) | (1L << APR) | (1L << JUN) | (1L << JUL) | (1L << AUG) | (1L << SEP) | (1L << OCT) | (1L << NOV) | (1L << DEC))) != 0)) ) {
			_errHandler.RecoverInline(this);
			}
			Consume();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.ReportError(this, re);
			_errHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class TimeValueContext : ParserRuleContext {
		public ITerminalNode WS(int i) {
			return GetToken(VBADateParser.WS, i);
		}
		public IReadOnlyList<TimeValuePartContext> timeValuePart() {
			return GetRuleContexts<TimeValuePartContext>();
		}
		public ITerminalNode AMPM() { return GetToken(VBADateParser.AMPM, 0); }
		public IReadOnlyList<ITerminalNode> WS() { return GetTokens(VBADateParser.WS); }
		public IReadOnlyList<TimeSeparatorContext> timeSeparator() {
			return GetRuleContexts<TimeSeparatorContext>();
		}
		public TimeValuePartContext timeValuePart(int i) {
			return GetRuleContext<TimeValuePartContext>(i);
		}
		public TimeSeparatorContext timeSeparator(int i) {
			return GetRuleContext<TimeSeparatorContext>(i);
		}
		public TimeValueContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_timeValue; } }
		public override void EnterRule(IParseTreeListener listener) {
			IVBADateListener typedListener = listener as IVBADateListener;
			if (typedListener != null) typedListener.EnterTimeValue(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IVBADateListener typedListener = listener as IVBADateListener;
			if (typedListener != null) typedListener.ExitTimeValue(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IVBADateVisitor<TResult> typedVisitor = visitor as IVBADateVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitTimeValue(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public TimeValueContext timeValue() {
		TimeValueContext _localctx = new TimeValueContext(_ctx, State);
		EnterRule(_localctx, 20, RULE_timeValue);
		int _la;
		try {
			State = 123;
			switch ( Interpreter.AdaptivePredict(_input,16,_ctx) ) {
			case 1:
				EnterOuterAlt(_localctx, 1);
				{
				{
				State = 97; timeValuePart();
				State = 101;
				_errHandler.Sync(this);
				_la = _input.La(1);
				while (_la==WS) {
					{
					{
					State = 98; Match(WS);
					}
					}
					State = 103;
					_errHandler.Sync(this);
					_la = _input.La(1);
				}
				State = 104; Match(AMPM);
				}
				}
				break;

			case 2:
				EnterOuterAlt(_localctx, 2);
				{
				{
				State = 106; timeValuePart();
				State = 107; timeSeparator();
				State = 108; timeValuePart();
				State = 112;
				switch ( Interpreter.AdaptivePredict(_input,13,_ctx) ) {
				case 1:
					{
					State = 109; timeSeparator();
					State = 110; timeValuePart();
					}
					break;
				}
				State = 121;
				_la = _input.La(1);
				if (_la==AMPM || _la==WS) {
					{
					State = 117;
					_errHandler.Sync(this);
					_la = _input.La(1);
					while (_la==WS) {
						{
						{
						State = 114; Match(WS);
						}
						}
						State = 119;
						_errHandler.Sync(this);
						_la = _input.La(1);
					}
					State = 120; Match(AMPM);
					}
				}

				}
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.ReportError(this, re);
			_errHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class TimeValuePartContext : ParserRuleContext {
		public ITerminalNode DIGIT(int i) {
			return GetToken(VBADateParser.DIGIT, i);
		}
		public IReadOnlyList<ITerminalNode> DIGIT() { return GetTokens(VBADateParser.DIGIT); }
		public TimeValuePartContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_timeValuePart; } }
		public override void EnterRule(IParseTreeListener listener) {
			IVBADateListener typedListener = listener as IVBADateListener;
			if (typedListener != null) typedListener.EnterTimeValuePart(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IVBADateListener typedListener = listener as IVBADateListener;
			if (typedListener != null) typedListener.ExitTimeValuePart(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IVBADateVisitor<TResult> typedVisitor = visitor as IVBADateVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitTimeValuePart(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public TimeValuePartContext timeValuePart() {
		TimeValuePartContext _localctx = new TimeValuePartContext(_ctx, State);
		EnterRule(_localctx, 22, RULE_timeValuePart);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 126;
			_errHandler.Sync(this);
			_la = _input.La(1);
			do {
				{
				{
				State = 125; Match(DIGIT);
				}
				}
				State = 128;
				_errHandler.Sync(this);
				_la = _input.La(1);
			} while ( _la==DIGIT );
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.ReportError(this, re);
			_errHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class TimeSeparatorContext : ParserRuleContext {
		public ITerminalNode DOT() { return GetToken(VBADateParser.DOT, 0); }
		public ITerminalNode WS(int i) {
			return GetToken(VBADateParser.WS, i);
		}
		public IReadOnlyList<ITerminalNode> WS() { return GetTokens(VBADateParser.WS); }
		public ITerminalNode COLON() { return GetToken(VBADateParser.COLON, 0); }
		public TimeSeparatorContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_timeSeparator; } }
		public override void EnterRule(IParseTreeListener listener) {
			IVBADateListener typedListener = listener as IVBADateListener;
			if (typedListener != null) typedListener.EnterTimeSeparator(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IVBADateListener typedListener = listener as IVBADateListener;
			if (typedListener != null) typedListener.ExitTimeSeparator(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IVBADateVisitor<TResult> typedVisitor = visitor as IVBADateVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitTimeSeparator(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public TimeSeparatorContext timeSeparator() {
		TimeSeparatorContext _localctx = new TimeSeparatorContext(_ctx, State);
		EnterRule(_localctx, 24, RULE_timeSeparator);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 133;
			_errHandler.Sync(this);
			_la = _input.La(1);
			while (_la==WS) {
				{
				{
				State = 130; Match(WS);
				}
				}
				State = 135;
				_errHandler.Sync(this);
				_la = _input.La(1);
			}
			State = 136;
			_la = _input.La(1);
			if ( !(_la==COLON || _la==DOT) ) {
			_errHandler.RecoverInline(this);
			}
			Consume();
			State = 140;
			_errHandler.Sync(this);
			_la = _input.La(1);
			while (_la==WS) {
				{
				{
				State = 137; Match(WS);
				}
				}
				State = 142;
				_errHandler.Sync(this);
				_la = _input.La(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.ReportError(this, re);
			_errHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public static readonly string _serializedATN =
		"\x3\xAF6F\x8320\x479D\xB75C\x4880\x1605\x191C\xAB37\x3%\x92\x4\x2\t\x2"+
		"\x4\x3\t\x3\x4\x4\t\x4\x4\x5\t\x5\x4\x6\t\x6\x4\a\t\a\x4\b\t\b\x4\t\t"+
		"\t\x4\n\t\n\x4\v\t\v\x4\f\t\f\x4\r\t\r\x4\xE\t\xE\x3\x2\x3\x2\x3\x2\x3"+
		"\x3\x3\x3\x6\x3\"\n\x3\r\x3\xE\x3#\x5\x3&\n\x3\x3\x3\x3\x3\x3\x3\x3\x4"+
		"\x3\x4\x3\x4\x3\x4\x6\x4/\n\x4\r\x4\xE\x4\x30\x3\x4\x3\x4\x5\x4\x35\n"+
		"\x4\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x5\x5=\n\x5\x3\x6\x3\x6\x5\x6"+
		"\x41\n\x6\x3\a\x6\a\x44\n\a\r\a\xE\a\x45\x3\b\x6\bI\n\b\r\b\xE\bJ\x3\b"+
		"\a\bN\n\b\f\b\xE\bQ\v\b\x3\b\x3\b\a\bU\n\b\f\b\xE\bX\v\b\x5\bZ\n\b\x3"+
		"\t\x3\t\x5\t^\n\t\x3\n\x3\n\x3\v\x3\v\x3\f\x3\f\a\f\x66\n\f\f\f\xE\fi"+
		"\v\f\x3\f\x3\f\x3\f\x3\f\x3\f\x3\f\x3\f\x3\f\x5\fs\n\f\x3\f\a\fv\n\f\f"+
		"\f\xE\fy\v\f\x3\f\x5\f|\n\f\x5\f~\n\f\x3\r\x6\r\x81\n\r\r\r\xE\r\x82\x3"+
		"\xE\a\xE\x86\n\xE\f\xE\xE\xE\x89\v\xE\x3\xE\x3\xE\a\xE\x8D\n\xE\f\xE\xE"+
		"\xE\x90\v\xE\x3\xE\x2\x2\x2\xF\x2\x2\x4\x2\x6\x2\b\x2\n\x2\f\x2\xE\x2"+
		"\x10\x2\x12\x2\x14\x2\x16\x2\x18\x2\x1A\x2\x2\a\x4\x2\x4\x4$$\x3\x2\x1F"+
		"!\x3\x2\x5\x10\x3\x2\x11\x1B\x3\x2\"#\x99\x2\x1C\x3\x2\x2\x2\x4\x1F\x3"+
		"\x2\x2\x2\x6\x34\x3\x2\x2\x2\b\x36\x3\x2\x2\x2\n@\x3\x2\x2\x2\f\x43\x3"+
		"\x2\x2\x2\xEY\x3\x2\x2\x2\x10]\x3\x2\x2\x2\x12_\x3\x2\x2\x2\x14\x61\x3"+
		"\x2\x2\x2\x16}\x3\x2\x2\x2\x18\x80\x3\x2\x2\x2\x1A\x87\x3\x2\x2\x2\x1C"+
		"\x1D\x5\x4\x3\x2\x1D\x1E\a\x2\x2\x3\x1E\x3\x3\x2\x2\x2\x1F%\a\x1E\x2\x2"+
		" \"\t\x2\x2\x2! \x3\x2\x2\x2\"#\x3\x2\x2\x2#!\x3\x2\x2\x2#$\x3\x2\x2\x2"+
		"$&\x3\x2\x2\x2%!\x3\x2\x2\x2%&\x3\x2\x2\x2&\'\x3\x2\x2\x2\'(\x5\x6\x4"+
		"\x2()\a\x1E\x2\x2)\x5\x3\x2\x2\x2*\x35\x5\b\x5\x2+\x35\x5\x16\f\x2,.\x5"+
		"\b\x5\x2-/\a$\x2\x2.-\x3\x2\x2\x2/\x30\x3\x2\x2\x2\x30.\x3\x2\x2\x2\x30"+
		"\x31\x3\x2\x2\x2\x31\x32\x3\x2\x2\x2\x32\x33\x5\x16\f\x2\x33\x35\x3\x2"+
		"\x2\x2\x34*\x3\x2\x2\x2\x34+\x3\x2\x2\x2\x34,\x3\x2\x2\x2\x35\a\x3\x2"+
		"\x2\x2\x36\x37\x5\n\x6\x2\x37\x38\x5\xE\b\x2\x38<\x5\n\x6\x2\x39:\x5\xE"+
		"\b\x2:;\x5\n\x6\x2;=\x3\x2\x2\x2<\x39\x3\x2\x2\x2<=\x3\x2\x2\x2=\t\x3"+
		"\x2\x2\x2>\x41\x5\f\a\x2?\x41\x5\x10\t\x2@>\x3\x2\x2\x2@?\x3\x2\x2\x2"+
		"\x41\v\x3\x2\x2\x2\x42\x44\a%\x2\x2\x43\x42\x3\x2\x2\x2\x44\x45\x3\x2"+
		"\x2\x2\x45\x43\x3\x2\x2\x2\x45\x46\x3\x2\x2\x2\x46\r\x3\x2\x2\x2GI\a$"+
		"\x2\x2HG\x3\x2\x2\x2IJ\x3\x2\x2\x2JH\x3\x2\x2\x2JK\x3\x2\x2\x2KZ\x3\x2"+
		"\x2\x2LN\a$\x2\x2ML\x3\x2\x2\x2NQ\x3\x2\x2\x2OM\x3\x2\x2\x2OP\x3\x2\x2"+
		"\x2PR\x3\x2\x2\x2QO\x3\x2\x2\x2RV\t\x3\x2\x2SU\a$\x2\x2TS\x3\x2\x2\x2"+
		"UX\x3\x2\x2\x2VT\x3\x2\x2\x2VW\x3\x2\x2\x2WZ\x3\x2\x2\x2XV\x3\x2\x2\x2"+
		"YH\x3\x2\x2\x2YO\x3\x2\x2\x2Z\xF\x3\x2\x2\x2[^\x5\x12\n\x2\\^\x5\x14\v"+
		"\x2][\x3\x2\x2\x2]\\\x3\x2\x2\x2^\x11\x3\x2\x2\x2_`\t\x4\x2\x2`\x13\x3"+
		"\x2\x2\x2\x61\x62\t\x5\x2\x2\x62\x15\x3\x2\x2\x2\x63g\x5\x18\r\x2\x64"+
		"\x66\a$\x2\x2\x65\x64\x3\x2\x2\x2\x66i\x3\x2\x2\x2g\x65\x3\x2\x2\x2gh"+
		"\x3\x2\x2\x2hj\x3\x2\x2\x2ig\x3\x2\x2\x2jk\a\x3\x2\x2k~\x3\x2\x2\x2lm"+
		"\x5\x18\r\x2mn\x5\x1A\xE\x2nr\x5\x18\r\x2op\x5\x1A\xE\x2pq\x5\x18\r\x2"+
		"qs\x3\x2\x2\x2ro\x3\x2\x2\x2rs\x3\x2\x2\x2s{\x3\x2\x2\x2tv\a$\x2\x2ut"+
		"\x3\x2\x2\x2vy\x3\x2\x2\x2wu\x3\x2\x2\x2wx\x3\x2\x2\x2xz\x3\x2\x2\x2y"+
		"w\x3\x2\x2\x2z|\a\x3\x2\x2{w\x3\x2\x2\x2{|\x3\x2\x2\x2|~\x3\x2\x2\x2}"+
		"\x63\x3\x2\x2\x2}l\x3\x2\x2\x2~\x17\x3\x2\x2\x2\x7F\x81\a%\x2\x2\x80\x7F"+
		"\x3\x2\x2\x2\x81\x82\x3\x2\x2\x2\x82\x80\x3\x2\x2\x2\x82\x83\x3\x2\x2"+
		"\x2\x83\x19\x3\x2\x2\x2\x84\x86\a$\x2\x2\x85\x84\x3\x2\x2\x2\x86\x89\x3"+
		"\x2\x2\x2\x87\x85\x3\x2\x2\x2\x87\x88\x3\x2\x2\x2\x88\x8A\x3\x2\x2\x2"+
		"\x89\x87\x3\x2\x2\x2\x8A\x8E\t\x6\x2\x2\x8B\x8D\a$\x2\x2\x8C\x8B\x3\x2"+
		"\x2\x2\x8D\x90\x3\x2\x2\x2\x8E\x8C\x3\x2\x2\x2\x8E\x8F\x3\x2\x2\x2\x8F"+
		"\x1B\x3\x2\x2\x2\x90\x8E\x3\x2\x2\x2\x16#%\x30\x34<@\x45JOVY]grw{}\x82"+
		"\x87\x8E";
	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN.ToCharArray());
}
} // namespace Rubberduck.Parsing
