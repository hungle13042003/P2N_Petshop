using P2N_Pet_API.Models.Product;
using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Query.Interface;
using P2N_Pet_API.UtilsService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Query
{
    public class ProductQuery : IProductQuery
    {
        private readonly IP2NPetDapper _p2NPetDapper;

        public ProductQuery(IP2NPetDapper p2NPetDapper)
        {
            _p2NPetDapper = p2NPetDapper;
        }

        public async Task<ProductDetailModel> QueryDetailProduct(ulong productDetailId, ulong brandid)
        {
			var selectBrand = @"";
			var conditionBrand = @"";

			if( brandid > 0)
            {
				conditionBrand = @" and brp.brandid = @BrandId ";

				selectBrand = @", brp.brandid BrandId, brp.address Address, brp.quantitybrand QuantityBrand ";
            }
            else
            {
				conditionBrand = "";
				selectBrand = "";
            }

			////Query đầu khi chưa upgrade category
			//var query =
			//	@"select detail.id ProductDetailId, concat(product.breedname, ' - ', col.title) ProductTitle, 
			//		product.breedid BreedId, product.breedname BreedName, 
			//		product.supplierid SupplierId, product.suppliername SupplierName,
			//		detail.sizeid, size.title sizetitle,
			//		detail.ageid AgeId, age.title AgeTitle, detail.price Price, detail.discount Discount, 
			//		(detail.price * (1 - detail.discount / 100)) PriceDiscount,
			//		case 
			//		when ifnull(pimage.image, N'') != '' 
			//		then CONCAT('" + Utils.LinkMedia("") + @"', 'Upload/PetDetail/PetDetail_Image/', pimage.image)
			//		else ifnull(pimage.image, '') 
			//		end ProductImage, product.Id ProductId, product.content Content, col.id ColorId, col.title ColorName,
			//		detail.sexid SexId, x.title SexTitle, detail.quantity Quantity
			//	from productdetail detail
			//		left join (
			//				select pdim.productdetailid, ifnull(pim.image, '') image
			//				from (
			//					select pif.productdetailid, min(pim.id) imageid
			//					from productimage pim 
			//						inner join productimagefor pif on pif.productimageid = pim.id
			//					where pim.status = 10 and pif.status = 10
			//					group by pif.productdetailid 
			//					) pdim 
			//					inner join productimage pim on pim.id = pdim.imageid
			//				order by pdim.productdetailid asc
			//			) pimage
			//			on pimage.productdetailid = detail.id
			//		inner join (
			//			select p.id, br.id breedid, br.name breedname, sup.id supplierid, sup.name suppliername, p.content
			//			from product p
			//				left join productdetail detail on detail.productid = p.id
			//				left join breed br on br.id = p.breedid
			//				left join supplier sup on sup.id = p.supplierid
			//			where p.status = 10 and br.status = 10 and sup.status = 10
			//			group by p.id, br.id, br.name, sup.id, sup.name, p.content 
			//			order by p.id asc
			//		) product on product.id = detail.productid
			//		left join color col on col.id = detail.colorid
			//		left join size on size.id = detail.sizeid
			//		left join age on age.id = detail.ageid
			//		left join sex x on x.id = detail.sexid
			//	where detail.status = 10 and detail.statusdetailid = 1 
			//		and col.status = 10 and size.status = 10 and age.status = 10
			//		and detail.id = @ProductDetailId";

			var query =
				@"select detail.id ProductDetailId, 
					case when product.breedname != '' then concat(product.breedname, ' - ', col.title)
						when product.categoryname != '' then concat(product.categoryname, ' - ', size.title)
                    end ProductTitle, 
					product.breedid BreedId, product.breedname BreedName,
                    product.categoryid CategoryId, product.categoryname CategoryName,
					product.supplierid SupplierId, product.suppliername SupplierName,
					detail.sizeid, size.title sizetitle,
					detail.ageid AgeId, age.title AgeTitle, detail.price Price, detail.discount Discount, 
					(detail.price * (1 - detail.discount / 100)) PriceDiscount,
					case 
					when ifnull(pimage.image, N'') != '' 
					then CONCAT('" + Utils.LinkMedia("") + @"', 'Upload/PetDetail/PetDetail_Image/', pimage.image)
					else ifnull(pimage.image, '') 
					end ProductImage, product.Id ProductId, product.content Content, col.id ColorId, col.title ColorName,
					detail.sexid SexId, x.title SexTitle, detail.quantity Quantity,
                    product.typeproductid TypeProductId, product.typeproductname TypeProductName" + selectBrand + @"
				from productdetail detail
					left join (
							select pdim.productdetailid, ifnull(pim.image, '') image
							from (
								select pif.productdetailid, min(pim.id) imageid
								from productimage pim 
									inner join productimagefor pif on pif.productimageid = pim.id
								where pim.status = 10 and pif.status = 10
								group by pif.productdetailid 
								) pdim 
								inner join productimage pim on pim.id = pdim.imageid
							order by pdim.productdetailid asc
						) pimage
						on pimage.productdetailid = detail.id
					inner join (
						select p.id, ifnull(br.id, 0) breedid, ifnull(br.name, '') breedname, sup.id supplierid, sup.name suppliername, p.content,
							ifnull(tp.id, 10) typeproductid, ifnull(tp.title, 'Thú cưng') typeproductname,
                            ifnull(p.categoryid, 0) categoryid, ifnull(cate.title, '') categoryname
						from product p
							left join productdetail detail on detail.productid = p.id
							left join (select * from breed where status = @Status) br on br.id = p.breedid
							left join (select * from supplier where status = @Status) sup on sup.id = p.supplierid
                            left join (select * from category where status = @Status) cate on cate.id = p.categoryid
                            left join ( select * from typeproduct where status = @Status) tp on tp.id = cate.typeproductid
						where p.status = 10
						group by p.id, br.id, br.name, sup.id, sup.name, p.content, 
							p.categoryid, tp.id, tp.title, cate.title
						order by p.id asc
					) product on product.id = detail.productid
					left join (select * from color where status = @Status) col on col.id = detail.colorid
					left join (select * from size where status = @Status) size on size.id = detail.sizeid
					left join (select * from age where status = @Status) age on age.id = detail.ageid
					left join (select * from sex where status = @Status) x on x.id = detail.sexid
					left join (
						select b.id brandid, b.address, bp.productdetailid, bp.quantity quantitybrand
						from brand b
							inner join brandproduct bp on b.id = bp.brandid
						where b.status = @Status and bp.status = @Status and bp.quantity > 0
					) brp on brp.productdetailid = detail.id
				where detail.status = 10 and detail.statusdetailid = 1 
					and detail.id = @ProductDetailId " + conditionBrand + @"";

			return await _p2NPetDapper.QuerySingleAsync<ProductDetailModel>(query, new
			{
				ProductDetailId = productDetailId,
				Status = 10,
				BrandId = brandid,
			});

		}

        public async Task<List<ProductListModel>> QueryListProduct(OSearchProductModel oSearch)
        {
			oSearch.CurrentPage = oSearch.CurrentPage < 0 ? 0 : oSearch.CurrentPage;
			oSearch.CurrentDate = string.IsNullOrEmpty(oSearch.CurrentDate)
				? Utils.DateNow().ToString("yyyy-MM-dd HH:mm:ss:fff")
				: oSearch.CurrentDate;

			oSearch.Limit = oSearch.Limit == 0 ? 25 : oSearch.Limit;

			var condition = @"";

			var limit = " limit @offset, @limit ";

			if(oSearch.BreedId > 0)
            {
				condition += @" and product.breedid = @BreedId";

				limit = " limit @offset, @limit ";
			}

			if (oSearch.BreedIdRoot > 0)
			{
				condition += @" and product.breedidroot = @BreedIdRoot";

				limit = " limit @offset, @limit ";
			}

			if (oSearch.SupplierId > 0)
            {
				condition += @" and product.supplierid = @SupplierId";

				limit = " limit @offset, @limit ";
			}

            if (!string.IsNullOrEmpty(oSearch.FindString))
            {
				condition += @" and (
									product.breedname like @FindString
									or
									col.title like @FindString
									or
									product.categoryname like @FindString
									or
									size.title like @FindString
								)";

				limit = " limit @offset, @limit ";
			}

			if(oSearch.TypeProducuctId > 0)
            {
				condition += @" and product.typeproductid = @TypeProductId";
            }

			if( oSearch.CategoryId > 0)
            {
				condition += @" and product.categoryid = @CategoryId";
            }

			if( oSearch.CategoryIdRoot > 0)
            {
				condition += @" and product.categoryidroot = @CategoryIdRoot";

			}

			if(oSearch.TopProduct > 0)
            {
				condition = @" and detail.discount > @Discount
							    # and datediff( @DateNow, detail.createdate) < 30";

				limit = @" order by detail.discount desc 
						limit @TopProduct";
            }

			////Query đầu khi chưa upgrade category
			//var query =
			//	@"select detail.id ProductDetailId, concat(product.breedname, ' - ', col.title) ProductTitle, product.breedid BreedId, product.breedname BreedName, product.supplierid SupplierId, 
			//		detail.price Price, detail.discount Discount, (detail.price * (1 - detail.discount / 100)) PriceDiscount,
			//		case 
			//		when ifnull(pimage.image, N'') != '' 
			//		then CONCAT('" + Utils.LinkMedia("") + @"', 'Upload/PetDetail/PetDetail_Image/', pimage.image)
			//		else ifnull(pimage.image, '') 
			//		end ProductImage, product.id ProductId, product.breedidroot BreedIdRoot, product.breedrootname BreedRootName, 
			//		product.SupplierName, detail.quantity ProductQuantity
			//	from productdetail detail
			//	left join (
			//			select pdim.productdetailid, ifnull(pim.image, '') image
			//			from (
			//				select pif.productdetailid, min(pim.id) imageid
			//				from productimage pim 
			//					inner join productimagefor pif on pif.productimageid = pim.id
			//				where pim.status = 10 and pif.status = 10
			//				group by pif.productdetailid
			//				) pdim 
			//				inner join productimage pim on pim.id = pdim.imageid
			//			order by pdim.productdetailid asc
			//		) pimage
			//		on pimage.productdetailid = detail.id
			//	inner join (
			//		select p.id, br.id breedid, br.name breedname, br.breedid breedidroot, root.name breedrootname,
			//			sup.id supplierid, sup.name suppliername, p.content
			//		from product p
			//			left join productdetail detail on detail.productid = p.id
			//			left join breed br on br.id = p.breedid
			//			left join breed root on root.id = br.breedid
			//			left join supplier sup on sup.id = p.supplierid
			//		where p.status = 10 and br.status = 10 and sup.status = 10 and root.status = 10
			//		group by p.id, br.id, br.name, br.breedid, root.name, sup.id, sup.name, p.content  
			//		order by p.id asc
			//	) product on product.id = detail.productid
			//	left join color col on col.id = detail.colorid
			//	where detail.status = 10 and detail.statusdetailid = 1 
			//		and col.status = 10 " + condition + @" 
			//	"+ limit + @"";

			var query =
				@"select detail.id ProductDetailId,
					case when product.breedname != '' then concat(product.breedname, ' - ', col.title)
						when product.categoryname != '' then concat(product.categoryname, ' - ', size.title)
                    end ProductTitle, 
					product.breedid BreedId, product.breedname BreedName,
                    product.categoryid CategoryId, product.categoryname CategoryName, product.supplierid SupplierId, 
					detail.price Price, detail.discount Discount, (detail.price * (1 - detail.discount / 100)) PriceDiscount,
					case 
					when ifnull(pimage.image, N'') != '' 
					then CONCAT('" + Utils.LinkMedia("") + @"', 'Upload/PetDetail/PetDetail_Image/', pimage.image)
					else ifnull(pimage.image, '') 
					end ProductImage, product.id ProductId, product.breedidroot BreedIdRoot, product.breedrootname BreedRootName, 
					product.SupplierName, detail.quantity ProductQuantity, 
                    product.categoryidroot CategoryIdRoot , product.categoryrootname CategoryRootName,
                    product.typeproductid TypeProductId, product.typeproductname TypeProductName
				from productdetail detail
				left join (
						select pdim.productdetailid, ifnull(pim.image, '') image
						from (
							select pif.productdetailid, min(pim.id) imageid
							from productimage pim 
								inner join productimagefor pif on pif.productimageid = pim.id
							where pim.status = 10 and pif.status = 10
							group by pif.productdetailid
							) pdim 
							inner join productimage pim on pim.id = pdim.imageid
						order by pdim.productdetailid asc
					) pimage
					on pimage.productdetailid = detail.id
				inner join (
					select p.id, ifnull(br.id, 0) breedid, ifnull(br.name, '') breedname, ifnull(br.breedid, 0) breedidroot, 
						ifnull(root.name, '') breedrootname, sup.id supplierid, sup.name suppliername, p.content,
                        ifnull(tp.id, 10) typeproductid, ifnull(tp.title, 'Thú cưng') typeproductname,
						ifnull(p.categoryid, 0) categoryid, ifnull(cate.title, '') categoryname,
                        ifnull(cate.categoryrootid, 0) categoryidroot, ifnull(cateroot.title, '') categoryrootname
					from product p
						left join productdetail detail on detail.productid = p.id
						left join (select * from breed where status = @Status) br on br.id = p.breedid
						left join (select * from breed where status = @Status) root on root.id = br.breedid
						left join (select * from supplier where status = @Status) sup on sup.id = p.supplierid
                        left join (select * from category where status = @Status) cate on cate.id = p.categoryid
                        left join (select * from category where status = @Status) cateroot on cateroot.id = cate.categoryrootid
                        left join (select * from typeproduct where status = @Status) tp on tp.id = cate.typeproductid
					where p.status = 10
					group by p.id, br.id, br.name, br.breedid, root.name, sup.id, sup.name, p.content  
					order by p.id asc
				) product on product.id = detail.productid
				left join (select * from color where status = @Status) col on col.id = detail.colorid
                left join (select * from size where status = @Status) size on size.id = detail.sizeid
				where detail.status = 10 and detail.statusdetailid = 1 " + condition + @"
				" + limit + @" ";

			return await _p2NPetDapper.QueryAsync<ProductListModel>(query, new
			{
				Breedid = oSearch.BreedId,
				BreedIdRoot = oSearch.BreedIdRoot,
				SupplierId = oSearch.SupplierId,
				FindString = "%" + oSearch.FindString.Trim() + "%",
				offset = oSearch.CurrentPage * oSearch.Limit,
				limit = oSearch.Limit,
				Discount = 10,
				TopProduct = oSearch.TopProduct,
				DateNow = Utils.DateNow(),
				Status = 10,
				TypeProductId = oSearch.TypeProducuctId,
				CategoryId = oSearch.CategoryId,
				CategoryIdRoot = oSearch.CategoryIdRoot
			});

		}

        public async Task<List<ProductSizeModel>> QueryListSizeOfProduct(ProductDetailConditionModel productDetailCondition)
        {
			var condition = @"";

			if(productDetailCondition.ColorId > 0)
            {
				condition += @" and detail.colorid = @ColorId ";
			}

			if( productDetailCondition.AgeId > 0)
            {
				condition += @" and detail.ageid = @AgeId ";
			}
			//var query =
			//	@"select detail.sizeid SizeId, sz.title SizeTitle
			//	from product p
			//		left join productdetail detail on p.id = detail.productid
			//		left join size sz on sz.id = detail.sizeid 
			//		left join color c on c.id = detail.colorid 
			//		left join age a on a.id = detail.ageid 
			//	where detail.statusdetailid = 1 and p.status = 10 and c.status = 10 and a.status = 10 
			//	and detail.status = 10 and sz.status = 10 and detail.productid = @Id and detail.colorid = @ColorId and detail.ageid = @AgeId 
			//	group by sz.id, detail.sizeid, sz.title ";

			var query =
				@"select detail.sizeid SizeId, sz.title SizeTitle
				from product p
					left join productdetail detail on p.id = detail.productid
					left join (select * from size where status = @Status) sz on sz.id = detail.sizeid 
					left join (select * from color where status = @Status) c on c.id = detail.colorid 
					left join (select * from age where status = @Status) a on a.id = detail.ageid 
				where detail.statusdetailid = 1 and p.status = 10 and detail.status = 10 
					and detail.productid = @Id " + condition + @"
				group by sz.id, detail.sizeid, sz.title ";

			return await _p2NPetDapper.QueryAsync<ProductSizeModel>(query, new
			{
				Status = 10,
				Id = productDetailCondition.ProductId,
				ColorId = productDetailCondition.ColorId,
				AgeId = productDetailCondition.AgeId
			});
		}

		public async Task<List<ProductAgeModel>> QueryListAgeOfProduct(ProductDetailConditionModel productDetailCondition)
		{
			var query =
				@"select detail.ageid AgeId, a.title AgeTitle
				from product p
					left join productdetail detail on p.id = detail.productid
					left join age a on a.id = detail.ageid 
					left join color c on c.id = detail.colorid 
				where detail.statusdetailid = 1 and p.status = 10 
				and detail.status = 10 and a.status = 10 and c.status = 10 and detail.productid = @Id and detail.colorid = @ColorId 
				group by a.id, detail.ageid, a.title ";

			return await _p2NPetDapper.QueryAsync<ProductAgeModel>(query, new
			{
				Id = productDetailCondition.ProductId,
				ColorId = productDetailCondition.ColorId
			});
		}

		public async Task<List<ProductColorModel>> QueryListColorOfProduct(ProductDetailConditionModel productDetailCondition)
		{
			var query =
				@"select detail.colorid ColorId, col.title ColorName
				from product p
					left join productdetail detail on p.id = detail.productid
					left join color col on col.id = detail.colorid
				where detail.statusdetailid = 1 and p.status = 10 
				and detail.status = 10 and col.status = 10 and detail.productid = @Id
				group by col.id, detail.colorid, col.title ";

			return await _p2NPetDapper.QueryAsync<ProductColorModel>(query, new
			{
				Id = productDetailCondition.ProductId
			});
		}

        public async Task<List<ProductSexModel>> QueryListSexOfProduct(ProductDetailConditionModel productDetailCondition)
        {
			var query =
				@"select detail.sexid SexId, x.title SexTitle
				from product p
					left join productdetail detail on p.id = detail.productid
					left join sex x on x.id = detail.sexid 
					left join size sz on sz.id = detail.sizeid 
					left join color c on c.id = detail.colorid 
					left join age a on a.id = detail.ageid 
				where detail.statusdetailid = 1 and p.status = 10 and sz.status = 10 and c.status = 10 and a.status = 10 
				and detail.status = 10 and detail.productid = @Id and detail.colorid = @Colorid and detail.ageid = @AgeId and detail.sizeid = @SizeId 
				group by x.id, detail.sexid, x.title ";

			return await _p2NPetDapper.QueryAsync<ProductSexModel>(query, new
			{
				Id = productDetailCondition.ProductId,
				ColorId = productDetailCondition.ColorId,
				AgeId = productDetailCondition.AgeId,
				SizeId = productDetailCondition.SizeId
			});

		}

        public async Task<int> QueryCountListProduct(OSearchProductModel oSearch)
        {
			oSearch.CurrentPage = oSearch.CurrentPage < 0 ? 0 : oSearch.CurrentPage;
			oSearch.CurrentDate = string.IsNullOrEmpty(oSearch.CurrentDate)
				? Utils.DateNow().ToString("yyyy-MM-dd HH:mm:ss:fff")
				: oSearch.CurrentDate;

			oSearch.Limit = oSearch.Limit == 0 ? 25 : oSearch.Limit;

			var condition = @"";

			if (oSearch.BreedId > 0)
			{
				condition += @" and product.breedid = @BreedId";
			}

			if (oSearch.BreedIdRoot > 0)
			{
				condition += @" and product.breedidroot = @BreedIdRoot";
			}

			if (oSearch.SupplierId > 0)
			{
				condition += @" and product.supplierid = @SupplierId";
			}

			if (!string.IsNullOrEmpty(oSearch.FindString))
			{
				condition += @" and (
									product.breedname like @FindString
									or
									col.title like @FindString
									or
									product.categoryname like @FindString
									or
									size.title like @FindString
								)";
			}

			if (oSearch.TypeProducuctId > 0)
			{
				condition += @" and product.typeproductid = @TypeProductId";
			}

			if (oSearch.CategoryId > 0)
			{
				condition += @" and product.categoryid = @CategoryId";
			}

			if (oSearch.CategoryIdRoot > 0)
			{
				condition += @" and product.categoryidroot = @CategoryIdRoot";

			}

			//var query =
			//	@"select count(1)
			//	from productdetail detail
			//	left join (
			//			select pdim.productdetailid, ifnull(pim.image, '') image
			//			from (
			//				select pif.productdetailid, min(pim.id) imageid
			//				from productimage pim 
			//					inner join productimagefor pif on pif.productimageid = pim.id
			//				where pim.status = 10 and pif.status = 10
			//				group by pif.productdetailid
			//				) pdim 
			//				inner join productimage pim on pim.id = pdim.imageid
			//			order by pdim.productdetailid asc
			//		) pimage
			//		on pimage.productdetailid = detail.id
			//	inner join (
			//		select p.id, br.id breedid, br.name breedname, br.breedid breedidroot, root.name breedrootname,
			//			sup.id supplierid, sup.name suppliername, p.content
			//		from product p
			//			left join productdetail detail on detail.productid = p.id
			//			left join breed br on br.id = p.breedid
			//			left join breed root on root.id = br.breedid
			//			left join supplier sup on sup.id = p.supplierid
			//		where p.status = 10 and br.status = 10 and sup.status = 10 and root.status = 10
			//		group by p.id, br.id, br.name, br.breedid, root.name, sup.id, sup.name, p.content 
			//		order by p.id asc
			//	) product on product.id = detail.productid
			//	left join color col on col.id = detail.colorid
			//	where detail.status = 10 and detail.statusdetailid = 1 
			//		and col.status = 10 " + condition + @" ;";

			var query =
				@"select count(1)
				from productdetail detail
				left join (
						select pdim.productdetailid, ifnull(pim.image, '') image
						from (
							select pif.productdetailid, min(pim.id) imageid
							from productimage pim 
								inner join productimagefor pif on pif.productimageid = pim.id
							where pim.status = 10 and pif.status = 10
							group by pif.productdetailid
							) pdim 
							inner join productimage pim on pim.id = pdim.imageid
						order by pdim.productdetailid asc
					) pimage
					on pimage.productdetailid = detail.id
				inner join (
					select p.id, ifnull(br.id, 0) breedid, ifnull(br.name, '') breedname, ifnull(br.breedid, 0) breedidroot, 
						ifnull(root.name, '') breedrootname, sup.id supplierid, sup.name suppliername, p.content,
                        ifnull(tp.id, 10) typeproductid, ifnull(tp.title, 'Thú cưng') typeproductname,
						ifnull(p.categoryid, 0) categoryid, ifnull(cate.title, '') categoryname,
                        ifnull(cate.categoryrootid, 0) categoryidroot, ifnull(cateroot.title, '') categoryrootname
					from product p
						left join productdetail detail on detail.productid = p.id
						left join (select * from breed where status = @Status) br on br.id = p.breedid
						left join (select * from breed where status = @Status) root on root.id = br.breedid
						left join (select * from supplier where status = @Status) sup on sup.id = p.supplierid
                        left join (select * from category where status = @Status) cate on cate.id = p.categoryid
                        left join (select * from category where status = @Status) cateroot on cateroot.id = cate.categoryrootid
                        left join (select * from typeproduct where status = @Status) tp on tp.id = cate.typeproductid
					where p.status = 10
					group by p.id, br.id, br.name, br.breedid, root.name, sup.id, sup.name, p.content  
					order by p.id asc
				) product on product.id = detail.productid
				left join (select * from color where status = @Status) col on col.id = detail.colorid
                left join (select * from size where status = @Status) size on size.id = detail.sizeid
				where detail.status = 10 and detail.statusdetailid = 1 " + condition + @" ;";

			return await _p2NPetDapper.QuerySingleAsync<int>(query, new
			{
				Breedid = oSearch.BreedId,
				BreedIdRoot = oSearch.BreedIdRoot,
				SupplierId = oSearch.SupplierId,
				FindString = "%" + oSearch.FindString.Trim() + "%",
				Status = 10,
				TypeProductId = oSearch.TypeProducuctId,
				CategoryId = oSearch.CategoryId,
				CategoryIdRoot = oSearch.CategoryIdRoot
			});
		}

        public async Task<ProductDetailModel> QueryMultiProductDetail(ProductDetailConditionModel productDetailCondition)
        {
			var conditionWhere = "";

			if(productDetailCondition.ProductDetailId > 0)
            {
				conditionWhere += @" and detail.id = @ProductDetailId ";
            }

			if(productDetailCondition.ProductId > 0)
            {
				conditionWhere += @" and detail.productid = @ProductId ";

				if(productDetailCondition.SizeId > 0)
                {
					conditionWhere += @" and detail.sizeid = @SizeId ";
                }

				if (productDetailCondition.ColorId > 0)
                {
					conditionWhere += @" and detail.colorid = @ColorId ";
                }

                if(productDetailCondition.AgeId > 0)
                {
					conditionWhere += @" and detail.ageid = @AgeId ";
                }

                if(productDetailCondition.SexId > 0)
                {
					conditionWhere += @" and detail.sexid = @SexId ";
                }
            }

			if( productDetailCondition.BrandId > 0)
            {
				conditionWhere += @" and brp.brandid = @BrandId";
            }

			//// Query chưa upgrade module 
			//var query =
			//	@"select detail.id ProductDetailId, concat(product.breedname, ' - ', col.title) ProductTitle, 
			//		product.breedid BreedId, product.breedname BreedName, 
			//		product.supplierid SupplierId, product.suppliername SupplierName,
			//		detail.sizeid, size.title sizetitle,
			//		detail.ageid AgeId, age.title AgeTitle, detail.price Price, detail.discount Discount, 
			//		(detail.price * (1 - detail.discount / 100)) PriceDiscount, product.Id ProductId, product.content Content, col.id ColorId, col.title ColorName,
			//		detail.sexid SexId, x.title SexTitle, detail.quantity Quantity
			//	from productdetail detail 
			//		inner join (
			//			select p.id, br.id breedid, br.name breedname,sup.id supplierid, sup.name suppliername, p.content
			//			from product p
			//				left join productdetail detail on detail.productid = p.id
			//				left join breed br on br.id = p.breedid
			//				left join supplier sup on sup.id = p.supplierid
			//			where p.status = 10 and br.status = 10 and sup.status = 10
			//			group by p.id, br.id, br.name, sup.id, sup.name, p.content 
			//			order by p.id asc
			//		) product on product.id = detail.productid
			//		left join color col on col.id = detail.colorid
			//		left join size on size.id = detail.sizeid
			//		left join age on age.id = detail.ageid
			//		left join sex x on x.id = detail.sexid

			//	where detail.status = 10 and detail.statusdetailid = 1 
			//		and col.status = 10 and size.status = 10 and age.status = 10 " + conditionWhere + @" ";

			var query =
				@"select detail.id ProductDetailId, 
					case when product.breedname != '' then concat(product.breedname, ' - ', col.title)
						when product.categoryname != '' then concat(product.categoryname, ' - ', size.title)
                    end ProductTitle, 
					product.breedid BreedId, product.breedname BreedName,
                    product.categoryid CategoryId, product.categoryname CategoryName, 
					product.supplierid SupplierId, product.suppliername SupplierName,
					detail.sizeid, size.title sizetitle,
					detail.ageid AgeId, age.title AgeTitle, detail.price Price, detail.discount Discount, 
					(detail.price * (1 - detail.discount / 100)) PriceDiscount, product.Id ProductId, product.content Content, col.id ColorId, col.title ColorName,
					detail.sexid SexId, x.title SexTitle, detail.quantity Quantity,
                    product.typeproductid TypeProductId, product.typeproductname TypeProductName,
					brp.brandid BrandId, brp.address Address, brp.quantitybrand QuantityBrand
				from productdetail detail 
					inner join (
						select p.id, ifnull(br.id, 0) breedid, ifnull(br.name, '') breedname, sup.id supplierid, sup.name suppliername, p.content,
							ifnull(tp.id, 10) typeproductid, ifnull(tp.title, 'Thú cưng') typeproductname,
                            ifnull(p.categoryid, 0) categoryid, ifnull(cate.title, '') categoryname
						from product p
							left join productdetail detail on detail.productid = p.id
							left join (select * from breed where status = @Status) br on br.id = p.breedid
							left join (select * from supplier where status = @Status) sup on sup.id = p.supplierid
                            left join (select * from category where status = @Status) cate on cate.id = p.categoryid
                            left join ( select * from typeproduct where status = @Status) tp on tp.id = cate.typeproductid
						where p.status = 10
						group by p.id, br.id, br.name, sup.id, sup.name, p.content, 
							p.categoryid, tp.id, tp.title, cate.title
						order by p.id asc
					) product on product.id = detail.productid
					left join (select * from color where status = @Status) col on col.id = detail.colorid
					left join (select * from size where status = @Status) size on size.id = detail.sizeid
					left join (select * from age where status = @Status) age on age.id = detail.ageid
					left join (select * from sex where status = @Status) x on x.id = detail.sexid
					left join (
						select b.id brandid, b.address, bp.productdetailid, bp.quantity quantitybrand
						from brand b
							inner join brandproduct bp on b.id = bp.brandid
						where b.status = @Status and bp.status = @Status and bp.quantity > 0
					) brp on brp.productdetailid = detail.id					
				where detail.status = 10 and detail.statusdetailid = 1" + conditionWhere + @" ";

			return await _p2NPetDapper.QuerySingleAsync<ProductDetailModel>(query, new
			{
				ProductDetailId = productDetailCondition.ProductDetailId,
				ProductId = productDetailCondition.ProductId,
				SizeId = productDetailCondition.SizeId,
				ColorId = productDetailCondition.ColorId,
				AgeId = productDetailCondition.AgeId,
				SexId = productDetailCondition.SexId,
				BrandId = productDetailCondition.BrandId,
				Status = 10
			});
		}

		public async Task<List<string>> QueryProductImages(ulong productDetailId)
        {
			var query =
				@"select case 
					when ifnull(pim.image, N'') != '' 
					then CONCAT('" + Utils.LinkMedia("") + @"', 'Upload/PetDetail/PetDetail_Image/', pim.image)
					else ifnull(pim.image, '') 
					end ProductImage 
				from productimage pim
					left join productimagefor pif on pif.productimageid = pim.id 
				where pim.status = @Status and pif.status = @Status and pif.productdetailid = @ProductDetailId 
				order by pim.id asc;";
			return await _p2NPetDapper.QueryAsync<string>(query, new
			{
				Status = 10,
				ProductDetailId = productDetailId
			});
        }

        public async Task<List<ProductBrandModel>> QueryListBrandOfProduct(ProductDetailConditionModel productDetailCondition)
        {
			var query =
				@"select bp.brandid BrandId, b.Address, bp.productdetailid ProductDetailId, bp.quantity QuantityInBrand
				from product p
					left join productdetail detail on p.id = detail.productid
					left join brandproduct bp on bp.productdetailid = detail.id
					left join brand b on b.id = bp.brandid
				where detail.statusdetailid = 1 and p.status = 10 and bp.status = 10 and b.status = 10 and bp.quantity > 0
				and detail.status = 10 and detail.id = @productId";

			return await _p2NPetDapper.QueryAsync<ProductBrandModel>(query, new
			{
				productId = productDetailCondition.ProductDetailId
			});
		}
    }
}
