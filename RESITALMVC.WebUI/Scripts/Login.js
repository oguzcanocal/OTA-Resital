var IslemSonucTurleri = {
    Basarili: "BAŞARILI",
    Hata: "HATA",
    Uyari: "UYARI",
    Bilgi: "BİLGİ"
};

var IslemSonucKodlari = {
    Basarili: 1,
    Hata: 2,
    Uyari: 3,
    Bilgi: 4
};



function ModalBilgilendirme(baslik, aciklama) {
    $("#MdlBaslik").text(baslik);
    $("#MdlAciklama").text(aciklama);
    ModalGoster("MdlBilgilendirme");
}
function ModalGoster(modalId) {
    $("#" + modalId).modal("show");
}
function ModalKapat(modalId) {
    $("#" + ModalId).modal("hide");
}
function Login() {
    try
    {
        var mail = $("#Mail").val();
        var pwd = $("#Sifre").val();

        if (mail == "") {
            ModalBilgilendirme("UYARI", "Kullanıcı Kodu Boş Geçilemez.");
            return false;
        }
        if (pwd == "") {
            alert("pwd");
            ModalBilgilendirme("UYARI", "Şifre boş geçilemez.");
            return false;
        }

        $.ajax({
            type: "POST",
            url: "/Account/Login",
            contents: "applications/json",
            dataType: "json",
            data: $("#FrmLogin").serialize(),
            async: true,
            success: function (data) {

                console.log(data);

                if (data.IslemKodu === 1) {
                    window.location.href = "../Account/Index"
                }
                else if (data.IslemKodu === 2) {
                    ModalBilgilendirme(IslemSonucTurleri.Hata, data.aciklama);
                }
            },
            error: function (ex) {
                ModalBilgilendirme(IslemSonucTurleri.Hata, data.aciklama);
            }


        });

    }

    catch (e) {
        console.log("Hata: " + e);

    }

}