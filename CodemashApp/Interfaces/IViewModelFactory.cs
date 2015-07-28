namespace CodemashApp.Interfaces
{
    public interface IViewModelFactory
    {
        TViewModel GetViewModel<TController, TViewModel>(TController controller);
    }
}