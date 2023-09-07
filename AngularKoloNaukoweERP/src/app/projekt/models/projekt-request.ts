export class ProjektRequest {
    idZespolu: Number;
    nazwa: string;
    terminRealizacji: Date;
    opis: string;

    constructor(idZespolu: Number, nazwa: string, terminRealizacji: Date, opis: string){
        this.idZespolu = idZespolu;
        this.nazwa = nazwa;
        this.terminRealizacji = terminRealizacji;
        this.opis = opis;
        console.log('request-projekt')
    }
    


}