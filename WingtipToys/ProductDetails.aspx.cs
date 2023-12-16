using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WingtipToys.Models;

namespace WingtipToys
{
    public partial class ProductDetails : System.Web.UI.Page
    {
        private int? ProductID { get => int.TryParse(Request["productID"], out int productId) ? productId : new int?(); }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindProductDetail(ProductID);
            }
        }

        private void BindProductDetail(int? productId)
        {
            if (!productId.HasValue || productId < 1) return;

            using (var db = WingtipToysDatabase.New)
            {
                var query = from p in db.GetTable<Product>()
                            where p.ProductID.Equals(productId)
                            select p;

                productDetail.DataSource = query;
                productDetail.DataBind();
            }
        }
    }
}