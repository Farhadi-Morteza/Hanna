namespace MudBlazor
{
    public interface IMrsSanackbar : IDisposable
    {
        IEnumerable<Snackbar> ShownSnackbars { get; }

        SnackbarConfiguration Configuration { get; }

        event Action OnSnackbarsUpdated;

        Snackbar Add(string message, Severity severity = Severity.Normal, Action<SnackbarOptions> configure = null);

        [Obsolete("Use Add instead.", true)]
        Snackbar AddNew(Severity severity, string message, Action<SnackbarOptions> configure);

        void Clear();

        void Remove(Snackbar snackbar);
    }
}
