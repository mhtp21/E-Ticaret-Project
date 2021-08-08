import React from "react";
import { Formik, Form } from "formik";
import * as Yup from "yup";
import { Button, FormField, Label, Input } from "semantic-ui-react";
import FormTextInput from "../utilities/customFormControls/FormTextInput";
 
export default function ProductAdd(){
    const initialValues = {Name:"",unitPrice:5,Description:"",}


    const schema = Yup.object({
        Name:Yup.string().required("Lütfen ürün adını giriniz"),
        unitPrice:Yup.number().required("Lütfen ürün fiyatını giriniz"),
        Description:Yup.string().required("Lütfen ürün tanımını yapınız")
    })

    return(
        <Formik 
      initialValues={initialValues} 
      validationSchema={schema}
      onSubmit = {(values)=>{
          console.log(values)
      }}
      >
        <Form className="ui form">
          <FormField>
            <Label>Ürün Resmi</Label>
            <Input placeholder="Ürün Resmi"/>
          </FormField>
          <FormTextInput name="Name" placeholder="Ürün adı"/>
          <FormTextInput name="unitPrice" placeholder="Ürün fiyatı"/>
          <FormTextInput name="Description" placeholder="Açıklama"/>
          <Button color="blue" type="submit">Ekle</Button>
        </Form>
      </Formik>
    )
}