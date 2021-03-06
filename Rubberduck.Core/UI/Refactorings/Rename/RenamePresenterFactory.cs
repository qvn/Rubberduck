using Rubberduck.Parsing.VBA;
using Rubberduck.UI.Refactorings;
using Rubberduck.UI.Refactorings.Rename;
using Rubberduck.VBEditor;
using Rubberduck.VBEditor.SafeComWrappers.Abstract;

namespace Rubberduck.Refactorings.Rename
{
    public class RenamePresenterFactory : IRefactoringPresenterFactory<RenamePresenter>
    {
        private readonly IVBE _vbe;
        private readonly IRefactoringDialog<RenameViewModel> _view;
        private readonly RubberduckParserState _state;

        public RenamePresenterFactory(IVBE vbe, IRefactoringDialog<RenameViewModel> view, RubberduckParserState state)
        {
            _vbe = vbe;
            _view = view;
            _state = state;
        }

        public RenamePresenter Create()
        {
            var activeSelection = _vbe.GetActiveSelection();
            var qualifiedSelection = activeSelection.HasValue ? activeSelection.Value : new QualifiedSelection(); 
            return new RenamePresenter(_view, new RenameModel(_vbe, _state, qualifiedSelection));
        }
    }
}
