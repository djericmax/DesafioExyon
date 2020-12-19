export class Voo{

    constructor() {
        this.id = 0;
        this.numdoVoo = '';
        this.assento = '';
        this.dataPartida = new Date;
        this.horapartida = new Date;
        this.valorPassagem = '';
        this.ciaAereaId = 0;
        this.passageiroId = 0;
    }

    id: number;
    numdoVoo: string;
    assento: string;
    dataPartida: Date;
    horapartida: Date;
    valorPassagem: string;
    ciaAereaId: Number;
    passageiroId: Number;
}