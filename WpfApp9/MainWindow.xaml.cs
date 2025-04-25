using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp9
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public class Product
        {
            public string Name { get; set; }
            public decimal Price { get; set; }
        }

        private List<Product> products = new List<Product>
        {
            new Product { Name = "Кроссовки Nike", Price = 7999  },
            new Product { Name = "Кроссовки Adidas", Price = 8499 },
            new Product { Name = "Кроссовки Puma", Price = 7299 },
            new Product { Name = "Смартфон Samsung", Price = 49999 },
            new Product { Name = "Смартфон iPhone", Price = 99999 },
            new Product { Name = "Смартфон Xiaomi", Price = 34999 },
            new Product { Name = "Ноутбук Lenovo", Price = 54999 },
            new Product { Name = "Ноутбук Asus", Price = 61999 },
            new Product { Name = "Ноутбук HP", Price = 57999 }
        };

        private List<Product> cart = new List<Product>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string query = SearchBox.Text.ToLower();
            ProductsList.ItemsSource = products.Where(p => p.Name.ToLower().Contains(query)).ToList();
        }

        private void AddToCart_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is Product product)
            {
                cart.Add(product);
                CartList.Items.Add($"{product.Name} - {product.Price:N0} ₽");
                UpdateTotalPrice();
            }
        }

        private void UpdateTotalPrice()
        {
            decimal total = cart.Sum(p => p.Price);
            TotalPriceText.Text = $"Итого: {total:N0} ₽";
        }

    }
}