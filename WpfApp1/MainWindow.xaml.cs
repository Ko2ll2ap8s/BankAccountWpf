using System.Windows;

namespace BankAccountWpf
{
    public partial class MainWindow : Window
    {
        private BankAccountNS.BankAccount account;

        public MainWindow()
        {
            InitializeComponent();

            account = new BankAccountNS.BankAccount("Mr.Roman Abramovich", 11.99);

            DataContext = account;
        }

        private void creditButton_Click(object sender, RoutedEventArgs e)
        {
            double amount;
            if (double.TryParse(amountTextBox.Text, out amount))
            {
                try
                {
                    account.Credit(amount);
                    balanceTextBlock.Text = account.Balance.ToString("C");
                }
                catch (System.ArgumentOutOfRangeException ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
        }
        private void debitButton_Click(object sender, RoutedEventArgs e)
        {
            double amount;
            if (double.TryParse(amountTextBox.Text, out amount))
            {
                try
                {
                    account.Debit(amount);
                    balanceTextBlock.Text = account.Balance.ToString("C");
                }
                catch (System.ArgumentOutOfRangeException ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
        }
    }
}
