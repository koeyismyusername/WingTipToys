using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WingtipToys.Logic;

namespace WingtipToys
{
    public partial class AddToCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var productIdString = Request.QueryString["ProductID"];
            if (!string.IsNullOrEmpty(productIdString) && int.TryParse(productIdString, out int productId))
            {
                using (var usersShoppingCart = new ShoppingCartActions())
                {
                    usersShoppingCart.AddToCart(productId);
                }
            }
            else
            {
                Debug.Fail("ERROR: We should never get to AddToCart.aspx without a productId.");
                throw new InvalidOperationException("쇼핑카트에 추가할 제품의 아이디를 알 수 없습니다.");
            }

            Response.Redirect("ShoppingCart.aspx");
        }
    }
}