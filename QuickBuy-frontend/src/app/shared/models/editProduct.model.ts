export class EditProductModel {
  constructor(
    public id: string,
    public name: string,
    public price: number,
    public quantity: number,
    public category: string,
    public imageSource: string,
    public description: string
  ) {}
}
