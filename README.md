# Shopping_Hexora
E-Ticaret Sitesi Oluşturma Projesi
Proje Başlığı: Shopping Hexora – E-Ticaret Platformu (Infotech Akademi Bitirme Projesi)

Proje Tanımı: Infotech Akademi eğitim süreci kapsamında geliştirilen bu proje; teknolojik ürünlerin sergilendiği, yönetildiği ve satın alma süreçlerinin simüle edildiği uçtan uca (Full-Stack) bir e-ticaret platformudur. Proje, modern yazılım mimarileri ve akademi gereklilikleri doğrultusunda şu özellikleri içermektedir:

Mimari ve Desenler: Veri erişim katmanında Generic Repository Pattern kullanılarak kod tekrarı önlenmiş ve SOLID prensiplerine uygun, sürdürülebilir bir yapı kurgulanmıştır.

Back-End Teknolojileri: Veritabanı yönetiminde Entity Framework Core (Code First) tercih edilmiştir. Ayrıca, sistemin dış servislerle etkileşimi için temel CRUD işlemlerini barındıran bir Web API katmanı entegre edilmiştir.

Yönetim ve Üyelik: Gelişmiş bir Admin Paneli üzerinden ürün ve kategori yönetimi sağlanmaktadır. ASP.NET Core Identity altyapısı ile güvenli bir üyelik sistemi (kayıt olma/giriş yapma) oluşturulmuştur.

E-Ticaret Modülleri: Kullanıcı dostu bir Frontend arayüzü eşliğinde; dinamik ürün filtreleme, sepet yönetimi ve ödeme formu (checkout) süreçleri aktif olarak çalışmaktadır.

Onay Mekanizması: Admin panelinde yer alan IsApproved kontrolü ile ürünlerin yayına alınma süreci denetlenmektedir.
