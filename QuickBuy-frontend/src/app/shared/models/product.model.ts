export class ProductModel {
  constructor(
    public id: string,
    public name: string,
    public ownerEmail: string,
    public price: number,
    public quantity: number,
    public category: string,
    public imageSource: string,
    public description: string
  ) {}
}
