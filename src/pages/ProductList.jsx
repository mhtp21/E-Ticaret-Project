import React, { useState, useEffect } from 'react';
import { Link } from "react-router-dom";
import { Button, Header, Menu, Table, TableCell,Image } from "semantic-ui-react";
import ProductService from "../services/productService";
import { useDispatch } from "react-redux";
import { addToCart } from "../store/actions/cartActions";
import { toast } from "react-toastify";

export default function ProductList() {

    const dispatch = useDispatch();

    const [products, setProducts] = useState([]);

    useEffect(()=>{
        let productService = new ProductService();
        productService.getProductsAll().then((result)=> setProducts(result.data.data))
    },[])

    const handleAddToCart = (product)=>{
        dispatch(addToCart(product));
        toast.success(`${product.name} sepete eklendi...`)
    }

    return (
        <div>
            <Table celled>
        <Table.Header>
          <Table.Row>
          <Table.HeaderCell>Ürün Fotoğrafı</Table.HeaderCell>
            <Table.HeaderCell>Ürün Adı</Table.HeaderCell>
            <Table.HeaderCell>Birim Fiyatı</Table.HeaderCell>
            <Table.HeaderCell>Kategori</Table.HeaderCell>
            <Table.HeaderCell>Açıklama</Table.HeaderCell>
            <Table.HeaderCell></Table.HeaderCell>
          </Table.Row>
        </Table.Header>
        <Table.Body>
          {products.map((product) => (
            <Table.Row key={product.id}>
              <TableCell>
                  <Header as='h4' image>
                  <Image src='/images/avatar/small/lena.png' rounded size='large' />
                  </Header>
              </TableCell>
              <Table.Cell>
                <Link to={`/products/${product.Name}`}>
                  {product.Name}
                </Link>
              </Table.Cell>
              <Table.Cell>{product.unitPrice}</Table.Cell>
              <Table.Cell>{product.unitsInStock}</Table.Cell>
              <Table.Cell>{product.Description}</Table.Cell>
              <Table.Cell>{product.CategoryId.Name}</Table.Cell>
              <Table.Cell>
                <Button onClick={()=>handleAddToCart(product)}>Sepete ekle</Button>
              </Table.Cell>
            </Table.Row>
          ))}
        </Table.Body>

        <Table.Footer>
          <Table.Row>
            <Table.HeaderCell colSpan="12">
              <Menu floated="right" pagination>
              </Menu>
            </Table.HeaderCell>
          </Table.Row>
        </Table.Footer>
      </Table>
        </div>
    )
}
