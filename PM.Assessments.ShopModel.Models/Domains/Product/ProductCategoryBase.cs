using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM.Assessments.ShopModel.Models.Domains.Product
{
    /// <summary>
    /// The base class for product category. It supports hierarchical representation of categories.
    /// </summary>
    public abstract class ProductCategoryBase
    {
        /// <summary>
        /// The category name.
        /// </summary>
        public required string Name { get; init; }
        /// <summary>
        /// A list of products that belong to this category. If there was no product in a category, this property may be null.
        /// </summary>
        public ICollection<ProductBase>? Products { get; private set; }
        /// <summary>
        /// A list of subcategories of this category. A category may have no subcategories and then, this property will be null.
        /// </summary>
        public ICollection<ProductCategoryBase>? SubCategories { get; private set; }
        /// <summary>
        /// The parent of this category. If the parent category was null, that means this category is a root category.
        /// </summary>
        public ProductCategoryBase? ParentCategory { get; private set; }
        /// <summary>
        /// This method will add a product to this category.
        /// </summary>
        /// <param name="product">The product to be added to this category.</param>
        public abstract void AddProduct(ProductBase product);
        /// <summary>
        /// This methods adds a category as a subcategory to this category.
        /// </summary>
        /// <param name="subCategory">The category to be added as a subcategory to this category.</param>
        /// <returns></returns>
        public abstract ProductCategoryBase AddSubCategory(ProductCategoryBase subCategory);
        /// <summary>
        /// This method removes a product from this category.
        /// </summary>
        /// <param name="product">The product to be removed from this category.</param>
        public abstract void RemoveProduct(ProductBase product);
        /// <summary>
        /// This method removes a category from the subcategories of this category.
        /// </summary>
        /// <param name="subCategory">The subcategory to be removed from the subcategories of this category.</param>
        public abstract void RemoveSubCategory(ProductCategoryBase subCategory);
        /// <summary>
        /// This method creates a hierarchical representation of this category and all of its subcategories to the leaf, like a tree structure.
        /// </summary>
        /// <returns>Returns a tree-like structure that contains this category as the root and all subcategories as tree nodes, to the leaf.</returns>
        public abstract IEnumerable<ProductCategoryBase> GetCategoriesHierarchy();
    }
}
