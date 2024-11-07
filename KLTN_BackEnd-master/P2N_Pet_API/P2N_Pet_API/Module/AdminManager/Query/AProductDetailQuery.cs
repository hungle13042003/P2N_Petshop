using P2N_Pet_API.Models.UtilsProject;
using P2N_Pet_API.Module.AdminManager.Models.AProductDetail;
using P2N_Pet_API.Module.AdminManager.Query.Interface;
using P2N_Pet_API.UtilsService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2N_Pet_API.Module.AdminManager.Query
{
    public class AProductDetailQuery : IAProductDetailQuery
    {
        private readonly IP2NPetDapper _p2NPetDapper;

        public AProductDetailQuery(IP2NPetDapper p2NPetDapper)
        {
            _p2NPetDapper = p2NPetDapper;
        }

        public async Task<List<AProductDetailListModel>> QueryGetListProductDetail(AOSearchProductDetail aOSearchProductDetail)
        {
            aOSearchProductDetail.Limit = string.IsNullOrEmpty(aOSearchProductDetail.Limit) ? "10" : aOSearchProductDetail.Limit;
            aOSearchProductDetail.CurrentDate = string.IsNullOrEmpty(aOSearchProductDetail.CurrentDate)
                ? Utils.DateNow().ToString("yyyy-MM-dd HH:mm:ss:fff")
                : aOSearchProductDetail.CurrentDate;
            aOSearchProductDetail.CurrentPage = string.IsNullOrEmpty(aOSearchProductDetail.CurrentPage) ? "0" : aOSearchProductDetail.CurrentPage;
            aOSearchProductDetail.BreedId = string.IsNullOrEmpty(aOSearchProductDetail.BreedId) ? "0" : aOSearchProductDetail.BreedId;
            aOSearchProductDetail.SupplierId = string.IsNullOrEmpty(aOSearchProductDetail.SupplierId) ? "0" : aOSearchProductDetail.SupplierId;
            aOSearchProductDetail.ColorId = string.IsNullOrEmpty(aOSearchProductDetail.ColorId) ? "0" : aOSearchProductDetail.ColorId;
            aOSearchProductDetail.SizeId = string.IsNullOrEmpty(aOSearchProductDetail.SizeId) ? "0" : aOSearchProductDetail.SizeId;
            aOSearchProductDetail.AgeId = string.IsNullOrEmpty(aOSearchProductDetail.AgeId) ? "0" : aOSearchProductDetail.AgeId;
            aOSearchProductDetail.SexId = string.IsNullOrEmpty(aOSearchProductDetail.SexId) ? "0" : aOSearchProductDetail.SexId;
            aOSearchProductDetail.StatusDetailId = string.IsNullOrEmpty(aOSearchProductDetail.StatusDetailId) ? "0" : aOSearchProductDetail.StatusDetailId;
            aOSearchProductDetail.Status = string.IsNullOrEmpty(aOSearchProductDetail.Status) ? "0" : aOSearchProductDetail.Status;

            var condition = @"";

            if (Convert.ToInt32(aOSearchProductDetail.BreedId) > 0)
            {
                condition += @" and br.id = @BreedId ";
            }

            if (Convert.ToInt32(aOSearchProductDetail.SupplierId) > 0)
            {
                condition += @" and su.id = @SupplierId ";
            }

            if (Convert.ToInt32(aOSearchProductDetail.ColorId) > 0)
            {
                condition += @" and pd.colorid = @ColorId ";
            }

            if (Convert.ToInt32(aOSearchProductDetail.SizeId) > 0)
            {
                condition += @" and pd.sizeid = @SizeId ";
            }

            if (Convert.ToInt32(aOSearchProductDetail.AgeId) > 0)
            {
                condition += @" and pd.ageid = @AgeId ";
            }

            if (Convert.ToInt32(aOSearchProductDetail.SexId) > 0)
            {
                condition += @" and pd.sexid = @SexId ";
            }

            if (Convert.ToInt32(aOSearchProductDetail.StatusDetailId) > 0)
            {
                condition += @" and pd.statusdetailid = @StatusDetailId ";
            }

            if (Convert.ToInt32(aOSearchProductDetail.Status) > 0)
            {
                condition += @" and pd.status = @Status ";
            }

            if (!string.IsNullOrEmpty(aOSearchProductDetail.CurrentDate))
            {
                condition += @" and pd.createdate <= cast(@CurrentDate as DateTime) ";
            }

            if( aOSearchProductDetail.CategoryId > 0)
            {
                condition += @" and ifnull(p.categoryid, 0) = @CategoryId ";
            }

            if( aOSearchProductDetail.TypeProductId > 0)
            {
                condition += @" and ifnull(tp.id, 10) = @TypeProductId ";
            }

            //var query =
            //    @"select pd.Id, ifnull(br.Name, N'') ProductName, ifnull(su.Name, N'') SupplierName, ifnull(cl.Title, N'') ColorTitle, ifnull(si.Title, N'') SizeTitle, 
            //        ifnull(ag.Title, N'') AgeTitle, ifnull(se.Title, N'') SexTitle, ifnull(sd.Title, N'') StatusDetailTitle, 
            //        pd.Price, pd.Discount, pd.Quantity, ifnull(st.Title, N'') StatusText, ifnull(uc.Name, N'') CreateUserName, 
            //        pd.CreateDate, ifnull(up.Name, N'') UpdateUserName, pd.UpdateDate 
            //    from productdetail pd  
            //        left join product p on p.id = pd.productid 
            //        left join breed br on br.id = p.breedid 
            //        left join color cl on cl.id = pd.colorid 
            //        left join size si on si.id = pd.sizeid 
            //        left join age ag on ag.id = pd.ageid 
            //        left join sex se on se.id = pd.sexid 
            //        left join statusdetail sd on sd.id = pd.statusdetailid 
            //     left join status st on st.id = pd.status
            //        left join users uc on uc.id = pd.createuser
            //        left join users up on up.id = pd.updateuser
            //        left join supplier su on su.id = p.supplierid
            //        left join category cate on cate.id = p.category
            //    where pd.status != @StatusExcep and p.status = @StatusRoot and br.status = @StatusRoot and cl.status= @StatusRoot and si.status= @StatusRoot and
            //          ag.status = @StatusRoot and se.status = @StatusRoot and sd.status = @StatusRoot and uc.status = @StatusRoot and up.status = @StatusRoot and 
            //          su.status = @StatusRoot " + condition + @" 
            //    order by pd.status asc, pd.statusdetailid asc, br.name collate utf8_unicode_ci asc 
            //    limit " + Convert.ToInt32(aOSearchProductDetail.Limit) * Convert.ToInt32(aOSearchProductDetail.CurrentPage) + @", " + aOSearchProductDetail.Limit + @";";

            var query =
                @"select pd.Id, case when ifnull(p.breedid, 0) != 0 then ifnull(br.Name, N'')
	                                when ifnull(p.categoryid, 0) != 0 then ifnull(cate.title, '') 
                                end ProductName, 
                    ifnull(su.Name, N'') SupplierName, ifnull(cl.Title, N'') ColorTitle, ifnull(si.Title, N'') SizeTitle, 
                    ifnull(ag.Title, N'') AgeTitle, ifnull(se.Title, N'') SexTitle, ifnull(sd.Title, N'') StatusDetailTitle, 
                    pd.Price, pd.Discount, pd.Quantity, ifnull(st.Title, N'') StatusText, ifnull(uc.Name, N'') CreateUserName, 
                    pd.CreateDate, ifnull(up.Name, N'') UpdateUserName, pd.UpdateDate 
                from productdetail pd  
                    left join product p on p.id = pd.productid 
                    left join (select * from breed where status = @StatusRoot) br on br.id = p.breedid 
                    left join (select * from color where status =@StatusRoot) cl on cl.id = pd.colorid 
                    left join (select * from size where status = @StatusRoot) si on si.id = pd.sizeid 
                    left join (select * from age where status = @StatusRoot) ag on ag.id = pd.ageid 
                    left join (select * from sex where status = @StatusRoot) se on se.id = pd.sexid 
                    left join (select * from statusdetail where status = @StatusRoot) sd on sd.id = pd.statusdetailid 
	                left join status st on st.id = pd.status
                    left join users uc on uc.id = pd.createuser
                    left join users up on up.id = pd.updateuser
                    left join (select * from supplier where status = @StatusRoot) su on su.id = p.supplierid
                    left join (select * from category where status = @StatusRoot) cate on cate.id = p.categoryid
                    left join (select * from typeproduct where status = 10) tp on tp.id = cate.typeproductid
                where pd.status != @StatusExcep and p.status = @StatusRoot and uc.status = @StatusRoot and up.status = @StatusRoot " + condition + @"
                order by pd.createdate desc, pd.status asc, pd.statusdetailid asc, br.name collate utf8_unicode_ci asc, cate.title collate utf8_unicode_ci asc
                limit " + Convert.ToInt32(aOSearchProductDetail.Limit) * Convert.ToInt32(aOSearchProductDetail.CurrentPage) + @", " + aOSearchProductDetail.Limit + @";";

            return await _p2NPetDapper.QueryAsync<AProductDetailListModel>(query, new
            {
                StatusExcep = 190,
                StatusRoot = 10,
                BreedId = aOSearchProductDetail.BreedId,
                SupplierId = aOSearchProductDetail.SupplierId,
                ColorId = aOSearchProductDetail.ColorId,
                SizeId = aOSearchProductDetail.SizeId,
                AgeId = aOSearchProductDetail.AgeId,
                SexId = aOSearchProductDetail.SexId,
                StatusDetailId = aOSearchProductDetail.StatusDetailId,
                Status = aOSearchProductDetail.Status,
                CurrentDate = aOSearchProductDetail.CurrentDate,
                CategoryId = aOSearchProductDetail.CategoryId,
                TypeProductId =  aOSearchProductDetail.TypeProductId
            });
        }

        public async Task<int> QueryCountListProductDetail(AOSearchProductDetail aOSearchProductDetail)
        {
            aOSearchProductDetail.Limit = string.IsNullOrEmpty(aOSearchProductDetail.Limit) ? "10" : aOSearchProductDetail.Limit;
            aOSearchProductDetail.CurrentDate = string.IsNullOrEmpty(aOSearchProductDetail.CurrentDate)
                ? Utils.DateNow().ToString("yyyy-MM-dd HH:mm:ss:fff")
                : aOSearchProductDetail.CurrentDate;
            aOSearchProductDetail.CurrentPage = string.IsNullOrEmpty(aOSearchProductDetail.CurrentPage) ? "0" : aOSearchProductDetail.CurrentPage;
            aOSearchProductDetail.BreedId = string.IsNullOrEmpty(aOSearchProductDetail.BreedId) ? "0" : aOSearchProductDetail.BreedId;
            aOSearchProductDetail.SupplierId = string.IsNullOrEmpty(aOSearchProductDetail.SupplierId) ? "0" : aOSearchProductDetail.SupplierId;
            aOSearchProductDetail.ColorId = string.IsNullOrEmpty(aOSearchProductDetail.ColorId) ? "0" : aOSearchProductDetail.ColorId;
            aOSearchProductDetail.SizeId = string.IsNullOrEmpty(aOSearchProductDetail.SizeId) ? "0" : aOSearchProductDetail.SizeId;
            aOSearchProductDetail.AgeId = string.IsNullOrEmpty(aOSearchProductDetail.AgeId) ? "0" : aOSearchProductDetail.AgeId;
            aOSearchProductDetail.SexId = string.IsNullOrEmpty(aOSearchProductDetail.SexId) ? "0" : aOSearchProductDetail.SexId;
            aOSearchProductDetail.StatusDetailId = string.IsNullOrEmpty(aOSearchProductDetail.StatusDetailId) ? "0" : aOSearchProductDetail.StatusDetailId;
            aOSearchProductDetail.Status = string.IsNullOrEmpty(aOSearchProductDetail.Status) ? "0" : aOSearchProductDetail.Status;

            var condition = @"";

            if (Convert.ToInt32(aOSearchProductDetail.BreedId) > 0)
            {
                condition += @" and br.id = @BreedId ";
            }

            if (Convert.ToInt32(aOSearchProductDetail.SupplierId) > 0)
            {
                condition += @" and su.id = @SupplierId ";
            }

            if (Convert.ToInt32(aOSearchProductDetail.ColorId) > 0)
            {
                condition += @" and pd.colorid = @ColorId ";
            }

            if (Convert.ToInt32(aOSearchProductDetail.SizeId) > 0)
            {
                condition += @" and pd.sizeid = @SizeId ";
            }

            if (Convert.ToInt32(aOSearchProductDetail.AgeId) > 0)
            {
                condition += @" and pd.ageid = @AgeId ";
            }

            if (Convert.ToInt32(aOSearchProductDetail.SexId) > 0)
            {
                condition += @" and pd.sexid = @SexId ";
            }

            if (Convert.ToInt32(aOSearchProductDetail.StatusDetailId) > 0)
            {
                condition += @" and pd.statusdetailid = @StatusDetailId ";
            }

            if (Convert.ToInt32(aOSearchProductDetail.Status) > 0)
            {
                condition += @" and pd.status = @Status ";
            }

            if (!string.IsNullOrEmpty(aOSearchProductDetail.CurrentDate))
            {
                condition += @" and pd.createdate <= cast(@CurrentDate as DateTime) ";
            }

            if (aOSearchProductDetail.CategoryId > 0)
            {
                condition += @" and ifnull(p.categoryid, 0) = @CategoryId ";
            }

            if (aOSearchProductDetail.TypeProductId > 0)
            {
                condition += @" and ifnull(tp.id, 10) = @TypeProductId ";
            }

            //var query =
            //    @"select pd.Id, ifnull(br.Name, N'') ProductName, ifnull(su.Name, N'') SupplierName, ifnull(cl.Title, N'') ColorTitle, ifnull(si.Title, N'') SizeTitle, 
            //        ifnull(ag.Title, N'') AgeTitle, ifnull(se.Title, N'') SexTitle, ifnull(sd.Title, N'') StatusDetailTitle, 
            //        pd.Price, pd.Discount, pd.Quantity, ifnull(st.Title, N'') StatusText, ifnull(uc.Name, N'') CreateUserName, 
            //        pd.CreateDate, ifnull(up.Name, N'') UpdateUserName, pd.UpdateDate 
            //    from productdetail pd  
            //        left join product p on p.id = pd.productid 
            //        left join breed br on br.id = p.breedid 
            //        left join color cl on cl.id = pd.colorid 
            //        left join size si on si.id = pd.sizeid 
            //        left join age ag on ag.id = pd.ageid 
            //        left join sex se on se.id = pd.sexid 
            //        left join statusdetail sd on sd.id = pd.statusdetailid 
            //     left join status st on st.id = pd.status
            //        left join users uc on uc.id = pd.createuser
            //        left join users up on up.id = pd.updateuser
            //        left join supplier su on su.id = p.supplierid
            //        left join category cate on cate.id = p.category
            //    where pd.status != @StatusExcep and p.status = @StatusRoot and br.status = @StatusRoot and cl.status= @StatusRoot and si.status= @StatusRoot and
            //          ag.status = @StatusRoot and se.status = @StatusRoot and sd.status = @StatusRoot and uc.status = @StatusRoot and up.status = @StatusRoot and 
            //          su.status = @StatusRoot " + condition + @" 
            //    order by pd.status asc, pd.statusdetailid asc, br.name collate utf8_unicode_ci asc 
            //    limit " + Convert.ToInt32(aOSearchProductDetail.Limit) * Convert.ToInt32(aOSearchProductDetail.CurrentPage) + @", " + aOSearchProductDetail.Limit + @";";

            var query =
                @"select count(1) 
                from productdetail pd  
                    left join product p on p.id = pd.productid 
                    left join (select * from breed where status = @StatusRoot) br on br.id = p.breedid 
                    left join (select * from color where status =@StatusRoot) cl on cl.id = pd.colorid 
                    left join (select * from size where status = @StatusRoot) si on si.id = pd.sizeid 
                    left join (select * from age where status = @StatusRoot) ag on ag.id = pd.ageid 
                    left join (select * from sex where status = @StatusRoot) se on se.id = pd.sexid 
                    left join (select * from statusdetail where status = @StatusRoot) sd on sd.id = pd.statusdetailid 
	                left join status st on st.id = pd.status
                    left join users uc on uc.id = pd.createuser
                    left join users up on up.id = pd.updateuser
                    left join (select * from supplier where status = @StatusRoot) su on su.id = p.supplierid
                    left join (select * from category where status = @StatusRoot) cate on cate.id = p.categoryid
                    left join (select * from typeproduct where status = 10) tp on tp.id = cate.typeproductid
                where pd.status != @StatusExcep and p.status = @StatusRoot and uc.status = @StatusRoot and up.status = @StatusRoot " + condition + @" ";

            return await _p2NPetDapper.QuerySingleAsync<int>(query, new
            {
                StatusExcep = 190,
                StatusRoot = 10,
                BreedId = aOSearchProductDetail.BreedId,
                SupplierId = aOSearchProductDetail.SupplierId,
                ColorId = aOSearchProductDetail.ColorId,
                SizeId = aOSearchProductDetail.SizeId,
                AgeId = aOSearchProductDetail.AgeId,
                SexId = aOSearchProductDetail.SexId,
                StatusDetailId = aOSearchProductDetail.StatusDetailId,
                Status = aOSearchProductDetail.Status,
                CurrentDate = aOSearchProductDetail.CurrentDate,
                CategoryId = aOSearchProductDetail.CategoryId,
                TypeProductId = aOSearchProductDetail.TypeProductId
            });
        }

        public async Task<AProductDetailModel> QueryGetInProductDetail(ulong Id)
        {
            var query = 
                @"select p.Id, pe.BreedId, pe.SupplierId, p.ColorId, p.SizeId, p.AgeId, 
                    p.SexId, p.StatusDetailId, p.Price, p.Discount, p.Quantity, p.Status,
                    pe.CategoryId
                from productdetail p  
                    left join product pe on pe.id = p.productid 
                where p.status != @StatusExcep and pe.status = @Status and p.id = @Id;";

            var productDetail = await _p2NPetDapper.QuerySingleAsync<AProductDetailModel>(query, new
            {
                StatusExcep = 190,
                Status = 10,
                Id
            });

            if(productDetail != null)
            {
                productDetail.aProductProductImageForModels = await QueryGetProductProductImageFor(productDetail.Id);
                productDetail.brands = await QueryListBrandProductDetail(productDetail.Id);
            }

            return productDetail;
        }

        public async Task<List<AProductProductImageForModel>> QueryGetProductProductImageFor(ulong productDetailId)
        {
            var query =
                @"select pif.id Id, pif.productimageid ProductImageId, 
                case 
					when ifnull(pim.image, N'') != '' 
					then CONCAT('" + Utils.LinkMedia("") + @"', 'Upload/PetDetail/PetDetail_Image/', pim.image)
					else ifnull(pim.image, '') 
                end Image 
                from productimagefor pif inner join productimage pim on pim.id = pif.productimageid 
                where pif.status = @Status and pim.status = @Status and pif.productdetailid = @ProductDetailId;";

            return await _p2NPetDapper.QueryAsync<AProductProductImageForModel>(query, new
            {
                Status = 10,
                ProductDetailId = productDetailId
            });
        }

        public async Task<List<ulong>> QueryListImageOldCreate(AProductDetailUpdateModel aProductDetailUpdateModel)
        {
            var query =
                @"select distinct pif.productimageid
                from productimagefor pif inner join 
	                (select distinct pd.id
	                from productdetail pd inner join 
		                productimagefor pif on pif.productdetailid = pd.id 
	                where pd.status = @Status and pif.status = @Status and pd.id != @ProductDetailId and 
		                pd.productid = @ProductId and pd.colorid = @ColorId and pd.ageid = @AgeId) old 
	                on old.id = pif.productdetailid;";

            return await _p2NPetDapper.QueryAsync<ulong>(query, new
            {
                Status = 10,
                ProductDetailId = aProductDetailUpdateModel.Id,
                ProductId = aProductDetailUpdateModel.ProductId,
                ColorId = aProductDetailUpdateModel.ColorId,
                AgeId = aProductDetailUpdateModel.AgeId
            });
        }

        public async Task<List<ulong>> QueryListProductDetailDuplicateImage(ulong productId, ulong colorId, ulong ageId)
        {
            var query = 
                @"select distinct p.id
                from productdetail p
                where p.status = @Status and p.productid = @ProductId and p.colorid = @ColorId 
                    and p.ageid = @AgeId;";

            return await _p2NPetDapper.QueryAsync<ulong>(query, new
            {
                Status = 10,
                ProductId = productId,
                ColorId = colorId,
                AgeId = ageId
            });
        }

        public async Task<List<ulong>> QueryListProductImageForDuplicateImage(ulong productImageId)
        {
            var query = 
                @"select p.id 
                from productimagefor p
                where p.status = @Status and p.productimageid = @ProductImageId;";

            return await _p2NPetDapper.QueryAsync<ulong>(query, new
            {
                Status = 10,
                ProductImageId = productImageId
            });
        }

        public async Task<ulong> GetProductId(ulong breedId, ulong supplierId)
        {
            var query =
                @"select id 
                from product 
                where status = @Status and breedid = @BreedId and supplierid = @SupplierId;";

            return await _p2NPetDapper.QuerySingleAsync<ulong>(query, new
            {
                Status = 10,
                BreedId = breedId,
                SupplierId = supplierId
            });
        }

        public async Task<List<ABrandProductDetailModel>> QueryListBrandProductDetail(ulong Id)
        {
            var query =
                @"select bp.BrandId, b.Address, bp.quantity QuantityInBrand
                from brandproduct bp
                    left join brand b on b.id = bp.brandid
                    left join productdetail p on p.id = bp.productdetailid
                where bp.status = 10 and b.status = 10 and p.status = 10 and p.id = @Id";

            var result = await _p2NPetDapper.QueryAsync<ABrandProductDetailModel>(query, new { Id });

            return result;
        }

        public async Task<ulong> GetProductIdByCategory(ulong categoryid, ulong supplierId)
        {
            var query =
                @"select id 
                from product 
                where status = @Status and categoryid = @Categoryid and supplierid = @SupplierId;";

            return await _p2NPetDapper.QuerySingleAsync<ulong>(query, new
            {
                Status = 10,
                Categoryid = categoryid,
                SupplierId = supplierId
            });
        }

        /// <summary>
        /// Lấy danh sách productdetailid cho các thức ăn phụ kiện trùng
        /// dùng cho hình ảnh tái sử dụng
        /// </summary>
        /// <param name="productId"> id sản phẩm</param>
        /// <returns></returns>
        public async Task<List<ulong>> QueryListProductDetailCategoryDuplicateImage(ulong productId)
        {
            var query =
                @"select distinct p.id
                from productdetail p
                where p.status = @Status and p.productid = @ProductId";

            return await _p2NPetDapper.QueryAsync<ulong>(query, new
            {
                Status = 10,
                ProductId = productId
            });
        }

        public async Task<List<ulong>> QueryListImageOldCategoryCreate(AProductDetailUpdateModel aProductDetailUpdateModel)
        {
            var query =
                @"select distinct pif.productimageid
                from productimagefor pif inner join 
	                (select distinct pd.id
	                from productdetail pd inner join 
		                productimagefor pif on pif.productdetailid = pd.id 
	                where pd.status = @Status and pif.status = @Status and pd.id != @ProductDetailId and 
		                pd.productid = @ProductId ) old 
	                on old.id = pif.productdetailid;";

            return await _p2NPetDapper.QueryAsync<ulong>(query, new
            {
                Status = 10,
                ProductDetailId = aProductDetailUpdateModel.Id,
                ProductId = aProductDetailUpdateModel.ProductId
            });
        }
    }
}
