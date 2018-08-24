﻿using System.Collections.Generic;
using System.Threading;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using Rubberduck.Parsing.Annotations;
using Rubberduck.Parsing.Rewriter;
using Rubberduck.Parsing.Symbols;
using Rubberduck.VBEditor;

namespace Rubberduck.Parsing.VBA.Parsing
{
    public struct ModuleParseResults
    {
        public ModuleParseResults(
            IParseTree codePaneParseTree,
            IParseTree attributesParseTree,
            IEnumerable<CommentNode> comments,
            IEnumerable<IAnnotation> annotations,
            IDictionary<(string scopeIdentifier, DeclarationType scopeType), Attributes> attributes,
            IModuleRewriter codePaneRewriter,
            IModuleRewriter attributesRewriter
        )
        {
            CodePaneParseTree = codePaneParseTree;
            AttributesParseTree = attributesParseTree;
            Comments = comments;
            Annotations = annotations;
            Attributes = attributes;
            CodePaneRewriter = codePaneRewriter;
            AttributesRewriter = attributesRewriter;
        }

        public IParseTree CodePaneParseTree { get; }
        public IParseTree AttributesParseTree { get; }
        public IEnumerable<CommentNode> Comments { get; }
        public IEnumerable<IAnnotation> Annotations { get; }
        public IDictionary<(string scopeIdentifier, DeclarationType scopeType), Attributes> Attributes { get; }
        public IModuleRewriter CodePaneRewriter { get; }
        public IModuleRewriter AttributesRewriter { get; }
    }

    public interface IModuleParser
    {
        ModuleParseResults Parse(QualifiedModuleName module, CancellationToken cancellationToken, TokenStreamRewriter rewriter = null);
    }
}