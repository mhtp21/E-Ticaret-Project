import axios from "axios";

export default class ProductService{
    getProductsAll(){
        return axios.get("https://localhost:44337/api/Products/getall")
    }

    getProductDetails(){
        return axios.get("https://localhost:44337/api/Products/getproductdetails")
    }

    getProductDetailsByMinPriceAndMaxPrice(){
        return axios.get("https://localhost:44337/api/Products/getproductdetailsbyminpriceandmaxprice")
    }

    getProductDetailsDesc(){
        return axios.get("https://localhost:44337/api/Products/getproductdetailsdesc")
    }

    getProductDetailsMeasurement(){
        return axios.get("https://localhost:44337/api/Products/getproductdetailsmeasurement")
    }

    getProductDetailsAsc(){
        return axios.get("https://localhost:44337/api/Products/getproductdetailasc")
    }

    getProductDetailsByPage(){
        return axios.get("https://localhost:44337/api/Products/getproductdetailsbypage")
    }

    getProductDetailsLimit(){
        return axios.get("https://localhost:44337/api/Products/getproductdetailslimit")
    }

    getProductDetailByProductId(productId){
        return axios.get("https://localhost:44337/api/Products/getproductdetailbyproductid?productId="+productId)
    }

    getProductDetailByBrandId(){
        return axios.get("https://localhost:44337/api/Products/getproductdetailbybrandid")
    }

    getProductDetailByCategoryId(){
        return axios.get("https://localhost:44337/api/Products/getproductdetailbycategoryid")
    }

    getByCategory(){
        return axios.get("https://localhost:44337/api/Products/getbycategory")
    }

    getProductAdd(){
        return axios.post("https://localhost:44337/api/Products/add")
    }

    getIdAdd(){
        return axios.post("https://localhost:44337/api/Products/getidadd")
    }

    getProductDelete(){
        return axios.post("https://localhost:44337/api/Products/delete")
    }

    getProductUpdate(){
        return axios.post("https://localhost:44337/api/Products/update")
    }
}