using System;
using System.Collections.Generic;
using Microsoft.Maui.Controls;

namespace Task5
{
    public partial class MainPage : ContentPage
    {
        List<object> Good = new List<object>();

        Random random = new Random();

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
            listView.ItemsSource = Good;
        }

        private void Add_Clicked(object sender, EventArgs e)
        {
            int rand = random.Next(1, 3);
            int price = random.Next(10, 1000);
            int quantity = random.Next(1,10);
            int states = random.Next(0, 5);
            string state = chooseState(states);
            int names = random.Next(0, 5);
            string product = chooseName(names);

            DateTime date = DateTime.Today;
            string formattedDate = date.ToString("yyyy-MM-dd");
            int day = random.Next(5, 100);
            DateTime expiration = DateTime.Today.AddDays(day);
            string formattedExpiration = expiration.ToString("yyyy-MM-dd");

            int books = random.Next(0, 3);
            string book = chooseBook(books);
            string author = chooseAuthor(books);
            int pages = choosePages(books);

            switch (rand)
            {
                case 1:
                    Good.Insert(0, new Products { 
                        Price = price, 
                        State = state,
                        Name = product, 
                        Date = formattedDate,
                        Description = "components, how to cook",
                        Expiration = formattedExpiration,
                        Quantity = quantity,
                        Unit = chooseUnit(names)
                    });

                    break;
                case 2:
                    Good.Insert(0, new Books
                    {
                        Price = price,
                        State = "Ukraine",
                        Name = book,
                        Description = "description",
                        Pages = pages,
                        Author = author,
                        Publishing = "А-БА-БА-ГА-ЛА-МА-ГА"
                    });
                    break;
            }

            listView.ItemsSource = null;
            listView.ItemsSource = Good;

        }

        private void Delete_Clicked(object sender, EventArgs e)
        {
            if (listView.SelectedItem is object selectedProduct)
            {
                Good.Remove(selectedProduct);
                listView.ItemsSource = null;
                listView.ItemsSource = Good;

            }
        }

        private string chooseState(int states)
        {
            string state = "";
            switch (states)
            {
                case 0:
                    state = "Ukraine";
                    break;
                case 1:
                    state = "Spain";
                    break;
                case 2:
                    state = "England";
                    break;
                case 3:
                    state = "France";
                    break;
                case 4:
                    state = "USA";
                    break;
            }
            return state;
        }

        private string chooseName(int names)
        {
            string name = "";
            switch (names)
            {
                case 0:
                    name = "Carrot";
                    break;
                case 1:
                    name = "Apple";
                    break;
                case 2:
                    name = "Cheese";
                    break;
                case 3:
                    name = "Butter";
                    break;
                case 4:
                    name = "Yoghurt";
                    break;
            }
            return name;
        }
        private string chooseUnit(int names)
        {
            string unit = "";
            switch (names)
            {
                case 0:
                    unit = "pieces";
                    break;
                case 1:
                    unit = "pieces";
                    break;
                case 2:
                    unit = "grams";
                    break;
                case 3:
                    unit = "grams";
                    break;
                case 4:
                    unit = "liters";
                    break;
            }
            return unit;
        }

        private string chooseBook(int books)
        {
            string book = "";
            switch (books)
            {
                case 0:
                    book = "Harry Potter and the Philosopher's Stone";
                    break;
                case 1:
                    book = "And Then There Were None";
                    break;
                case 2:
                    book = "The Hobbit";
                    break;
            }
            return book;
        }
        private string chooseAuthor(int books)
        {
            string author = "";
            switch (books)
            {
                case 0:
                    author = "J. K. Rowling";
                    break;
                case 1:
                    author = "Agatha Christie";
                    break;
                case 2:
                    author = "J. R. R. Tolkien";
                    break;
            }
            return author;
        }
        private int choosePages(int books)
        {
            int pages = 0;
            switch (books)
            {
                case 0:
                    pages = 223;
                    break;
                case 1:
                    pages = 272;
                    break;
                case 2:
                    pages = 304;
                    break;
            }
            return pages;
        }
    }
}
