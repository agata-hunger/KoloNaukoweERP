export class ProjektRequest {
    idZespolu: number;
    nazwa: string;
    terminRealizacji: Date;
    opis: string;

    constructor(idZespolu: number, nazwa: string, terminRealizacji: Date, opis: string){
        this.idZespolu = idZespolu;
        this.nazwa = nazwa;
        this.terminRealizacji = terminRealizacji;
        this.opis = opis;
        console.log('request-projekt')
    }
    
}