export class CzlonekRequest {
    idPelnionejFunkcji: number;
    idCzlonekZespol: number;
    kierunekStudiow: string;
    nrTelefonu: string;
    mail: string;
    nazwisko: string;
    imie: string;
    uczelnia: string;
    wydzial: string;

    constructor(idPelnionejFunkcji: number, idCzlonekZespol: number, kierunekStudiow: string, nrTelefonu: string, mail: string, nazwisko: string, imie: string, uczelnia: string, wydzial: string){
        this.idPelnionejFunkcji = idPelnionejFunkcji;
        this.idCzlonekZespol = idCzlonekZespol;
        this.kierunekStudiow = kierunekStudiow;
        this.nrTelefonu = nrTelefonu;
        this.mail = mail;
        this.nazwisko = nazwisko;
        this.imie = imie;
        this.uczelnia = uczelnia;
        this.wydzial = wydzial;
        console.log('request-czlonek')
    }
    
}