using System.Collections.Generic;

using CMS.Ecommerce;

namespace DancingGoat.Repositories
{
    /// <summary>
    /// Interface for classes providing CRUD operations for product variants.
    /// </summary>
    public interface IVariantRepository : IRepository
    {
        /// <summary>
        /// Returns a variant with the specified identifier.
        /// </summary>
        /// <param name="variantId">Product variant's SKU object identifier.</param>
        /// <returns><see cref="ProductVariant"/> object representing a product variant with the specified identifier. Returns <c>null</c> if not found.</returns>
        ProductVariant GetById(int variantId);


        /// <summary>
        /// Returns an enumerable collection of all variants of the given product.
        /// </summary>
        /// <param name="productId">SKU object identifier of the variant's parent product.</param>
        /// <returns>Collection of product variants. See <see cref="ProductVariant"/> for detailed information.</returns>
        IEnumerable<ProductVariant> GetByProductId(int productId);


        /// <summary>
        /// Returns a variant for the given parent product which consists of the specified options.
        /// If multiple variants use the given subset of options, one of them is returned (based on setting of the database engine).
        /// </summary>
        /// <param name="productId">SKU identifier of the variant's parent product.</param>
        /// <param name="optionIds">Collection of the variant's product options.</param>
        /// <returns><see cref="ProductVariant"/> object representing a product variant assembled from the specified information. Returns <c>null</c> if such variant does not exist.</returns>
        ProductVariant GetByProductIdAndOptions(int productId, IEnumerable<int> optionIds);


        /// <summary>
        /// Returns a collection of option categories used in a product's variants.
        /// </summary>
        /// <param name="productId">SKU identifier of the variant's parent product.</param>
        /// <returns>Collection of option categories used in a product's variants. See <see cref="OptionCategoryInfo"/> for detailed information.</returns>
        IEnumerable<OptionCategoryInfo> GetVariantOptionCategories(int productId);
    }
}
