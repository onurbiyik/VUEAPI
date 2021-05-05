# .Net API projesinde JWT, Windows Authentication ve anonim endpointlerin birlikte kullanımı

## IIS yapılandırması
![image](https://user-images.githubusercontent.com/6241024/117143742-d2ac6300-adb9-11eb-8905-553089b76694.png)


## Endpointler
Anonim endpoint: https://localhost:5555/weatherforecast
Windows Auth endpoint: https://localhost:5555/WinOt
JWT endpoint: https://localhost:5555/cevat



## XMLHTTP Çağrılarında windows credential bilgisinin geçilmesi

```
            fetch('https://localhost:5555/WinOt',
                { credentials: 'include', method: 'post' })
```

## HTTP/2 kullanımında `NET:ERR_UNEXPECTED` hatası.
Chrome ve Edge tarayıcıları, ilk açıldığında, windows authentication endpoint çağrısı yaparken `NET:ERR_UNEXPECTED` hatası vermektedir. Windows Authentication HTTP2 üzerinde desteklenmediği için HTTP2 -> 1.1 downgrade işlemi sırasında bu hata alınmaktadır.

Çözüm için HTTP/2 kapatılır.
![image](https://user-images.githubusercontent.com/6241024/117143942-0a1b0f80-adba-11eb-99ef-c28a252a50bb.png)


### Test için vue projesinin çalıştırılması
```
npm run serve
```
vue projesi https://github.com/onurbiyik/VUEAPI altındadır. 
