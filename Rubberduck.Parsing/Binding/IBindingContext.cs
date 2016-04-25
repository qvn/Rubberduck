﻿using Antlr4.Runtime;
using Rubberduck.Parsing.Symbols;

namespace Rubberduck.Parsing.Binding
{
    public interface IBindingContext
    {
        IBoundExpression Resolve(Declaration module, Declaration parent, ParserRuleContext expression);
    }
}
