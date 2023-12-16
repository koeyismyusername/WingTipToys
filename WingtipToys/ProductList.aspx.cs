using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using WingtipToys.Models;

namespace WingtipToys
{
    public partial class ProductList : System.Web.UI.Page
    {
        private int? CategoryID { get => int.TryParse(Request["id"], out int categoryId) ? categoryId : new int?(); }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindProductList(CategoryID);
            }
        }

        private void BindProductList(int? categoryId)
        {
            using (var db = WingtipToysDatabase.New)
            {
                var query = from data in db.GetTable<Product>() select data;

                if (query != null && categoryId.HasValue && categoryId > 0)
                {
                    query = query.Where(x => x.CategoryID.Equals(categoryId));
                }

                productList.DataSource = query;
                productList.DataBind();
            }
        }
    }
}