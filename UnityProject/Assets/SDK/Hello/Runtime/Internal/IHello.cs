using System.Threading.Tasks;

internal interface IHello {
    void Print(string message);
    void ShowDialog();
    void Call();
    void Callback();
    Task<int> CallAsync();
}
