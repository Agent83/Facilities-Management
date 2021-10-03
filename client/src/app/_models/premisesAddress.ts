export interface PremisesAddress {
    id: number;
    addressLine1: string;
    addressLine2: string;
    city: string;
    town: string;
    postCode: string;
    isDeleted: boolean;
    premises?: any;
}
