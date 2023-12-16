using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WingtipToys.Dtos;
using WingtipToys.Logic;
using WingtipToys.Models;

namespace WingtipToys
{
    public partial class ShoppingCart : Page, IDisposable
    {
        private readonly ShoppingCartActions shoppingCartActions = new ShoppingCartActions();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<ShoppingCartDto> GetShoppingCartItems()
        {
            return shoppingCartActions.GetCartItems();
        }

        public override void Dispose()
        {
            shoppingCartActions.Dispose();
        }

        ~ShoppingCart()
        {
            Dispose();
        }
    }
}