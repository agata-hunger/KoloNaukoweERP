export class SprzetRequest {
    nazwa: string;
    opis: string;
    czyDostepny: boolean;


    constructor(nazwa: string, opis: string, czyDostepny: boolean){
        this.nazwa = nazwa;
        this.opis = opis;
        this.czyDostepny = czyDostepny;

        console.log('request-sprzet')
    }
    
}