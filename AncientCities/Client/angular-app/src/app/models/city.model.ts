import { CityType } from "./city-type";

export class City {
  id: number = 0;
  name: string = '';
  partOf: string = '';
  population?: number;
  created?: Date;
  eraCreated?: string = '';
  defunct?: Date;
  eraDefunct?: string = '';
  description?: string;
  typeId?: number;
  type?: CityType;
}

