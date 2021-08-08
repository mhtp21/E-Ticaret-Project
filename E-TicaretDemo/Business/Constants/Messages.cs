﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string[] ValidImageFileTypes = { ".JPG", ".JPEG", ".PNG", ".TIF", ".TIFF", ".GIF", ".BMP", ".ICO" };

        public static string ProductAdded = "Ürün eklendi";
        public static string AddressFilterCity = "Şehire göre adresler listelendi";
        public static string AddressAdded = "Adres eklendi";
        public static string AddressDeleted = "Adres silindi";
        public static string AddressUpdated = "Adres güncellendi";
        public static string UserAdded = "Kullanıcı eklendi";
        public static string UserDeleted = "Kullanıcı silindi";
        public static string UserUpdated = "Kullanıcı güncellendi";
        public static string UserNotFound = "Kullanıcı bulunamadı.";
        public static string PasswordError = "Parola hatası.";
        public static string SuccessFulLoginAccess = "Giriş başarılı";
        public static string UserAlreadyExist = "Bu kullanıcı zaten mevcut";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi.";
        public static string AccessTokenCreated = "Erişim izni verildi.";
        public static string AuthorizationDenied = "Yetkiniz yok.";
        public static string AddedBasket = "Sepete eklendi";
        public static string DeletedBasket = "Sepetten silindi";
        public static string UpdatedBasket = "Ürün güncellendi";
        public static string AddedOrder = "Sipariş başarılı";
        public static string DeletedOrder = "Sipariş silindi";
        public static string UpdatedOrder = "Sipariş güncellendi";
        public static string AddedComment = "Yorum başarılı";
        public static string DeletedComment = "Yorum silindi";
        public static string UpdatedComment = "Yorum güncellendi";
        public static string ProductDeleted = "Ürün silindi";
        public static string ProductUpdated = "Ürün güncellendi";
        public static string PaymentAdded = "Kredi kartı eklendi";
        public static string DeletedCustomerCreditCard = "Kayıtlı kart silindi";
        public static string FavoriteAdded = "Ürün beğenildi";
        public static string FavoriteDeleted = "Beğenilerinizden kaldırıldı";
        public static string FavoriteUpdated = "Beğeni güncellendi";
        public static string CommentDeleted = "Yorum silindi";
        public static string PasswordChanged = "Şifre değiştirildi";
        public static string OldPasswordWrong = "Eski şifre yanlış";
        public static string InvalidImageExtension = "Geçersiz dosya uzantısı, fotoğraf için kabul edilen uzantılar" + string.Join(",", ValidImageFileTypes);

    }
}
