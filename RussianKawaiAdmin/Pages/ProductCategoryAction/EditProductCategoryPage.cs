using RussianKawaiShop;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpServer;

namespace RussianKawaiAdmin.Pages.Products
{
    class EditProductcategoryPage : RussianKawaiAdmin
    {
        public override PageType PageType
        {
            get { return PageType.Multi; }
        }
        public override string URL
        {
            get { return "/product.category/edit/"; }
        }
        public override string TemplateAddr
        {
            get { return "ProductCategory.Edit.html"; }
        }

        private ProductCategoryService productCategoryService = new ProductCategoryServiceImpl();
        public override bool Init(Client client)
        {
            int productCategoryID;
            if (int.TryParse(BaseFuncs.GetAdditionalURLArray(client.URL, this.URL)[0], out productCategoryID))
            {
                ProductCategory productCategory = productCategoryService.GetByID(productCategoryID);
                if (productCategory != null)
                {
                    Hashtable data = new Hashtable();

                    if (client.PostParam("EditProductCategory") != null)
                    {
                        if (client.PostParam("name") != null)
                        {
                            productCategory.Name = client.PostParam("name");
                            productCategory.Image = client.PostParam("image");
                            productCategory.Description = client.PostParam("desc");
                            productCategoryService.EditCategory(productCategory);

                            client.Redirect("/product.category/#pr_" + productCategory.ID);
                            Logger.ConsoleLog("Edited product category: " + productCategory.Name + " (ID: " + productCategory.ID + ")", ConsoleColor.Yellow);

                            return false;
                        }
                    }
                    data.Add("ProductCategory", productCategory);
                    client.HttpSend(TemplateActivator.Activate(this, client, data));
                    return true;
                }  
            }


            BaseFuncs.Show404(client);
            return false;
        }
    }
}
