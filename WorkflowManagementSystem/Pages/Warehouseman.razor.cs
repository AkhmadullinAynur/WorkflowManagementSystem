using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using WorkflowManagementSystem.Data;

namespace WorkflowManagementSystem.Pages
{
    public partial class Warehouseman
    {
        List<Product> merchandises = new List<Product>();
        List<Product> typeList = MongoDataBase.GetTypeList();
        private string _nameProduct;
        private string _typeProduct;
        private string _manufacturer;
        private int _quantity;
        private int _article;

        private bool _buttonActive;
        private bool _newAddActive;
        private bool _editTypeActive;
        private bool _editProductActive;
        private bool _newAddComplete;
        private bool _newTypeComplete;
        private bool _editComplete;

        private void NewAddActive()
        {
            MessageFalse();
            _newAddActive = !_newAddActive;
            _buttonActive = true;
        }
        private void EditTypeActive()
        {
            MessageFalse();
            _editTypeActive = !_editTypeActive;
            _buttonActive = true;
        }
        private void EditProductActive(int article)
        {
            merchandises = MongoDataBase.FindProduct(article);
            foreach (var item in merchandises)
            {
                _nameProduct = item.Name;
                _manufacturer = item.Manufacturer;
                _typeProduct = item.TypeProduct;
                _article = item.Article;
                _quantity = item.Quantity;
            }
            MessageFalse();
            _editProductActive = true;
            _buttonActive = true;
        }
        private void Cancel()
        {
            MessageFalse();
            Refresh();
            _buttonActive = false;
            _newAddActive = false;
            _editTypeActive = false;
            _editProductActive = false;
        }
        private void Refresh()
        {
            _nameProduct = string.Empty;
            _typeProduct = string.Empty;
            _manufacturer = string.Empty;
            _quantity = 0;

        }
        private void MessageFalse()
        {
            _newAddComplete = false;
            _newTypeComplete = false;
            _editComplete = false;
        }

        protected override void OnInitialized()
        {
            productService.merchandises = MongoDataBase.GetProductList();
            typeList = MongoDataBase.GetTypeList();
        }

        private void AddProduct()
        {
            merchandises = MongoDataBase.GetProductList();
            int newArticle = 1000000;
            int article = newArticle;
            foreach (var item in merchandises)
            {
                article = item.Article;
            }
            for (int i = 1000000; i <= article + 1; i++)
            {
                newArticle = i;
            }
            MongoDataBase.AddProductToDB(new Product(_nameProduct, _typeProduct, _manufacturer, newArticle, _quantity));
            OnInitialized();
            Refresh();
            Cancel();
            _newAddComplete = true;
        }
        private void AddTypeToDB()
        {
            MongoDataBase.AddTypeToDB(new Product(_typeProduct));
            OnInitialized();
            Refresh();
            Cancel();
            _newTypeComplete = true;
        }

        private void SelectionType(ChangeEventArgs args)
        {
            var newBuffTasks = typeList.Find(x => x.TypeProduct == args.Value.ToString());
            _typeProduct = newBuffTasks.TypeProduct;
            //merchandises.Add(new Merchandise(_typeProduct));
            OnInitialized();
        }
        private void DeleteProduct(int article)
        {
            MongoDataBase.DeleteProduct(article);
            OnInitialized();
            MessageFalse();
        }
        private void ReplaceProduct()
        {
            MongoDataBase.ReplaceProduct(_article, new Product(_nameProduct, _typeProduct, _manufacturer, _article, _quantity));
            OnInitialized();
            Refresh();
            Cancel();
            _editComplete = true;
        }

        private void MinusClick()
        {
            if (_quantity > 0)
            {
                _quantity--;
            }
        }
        private void PlusClick()
        {
            _quantity++;
        }
    }
}
