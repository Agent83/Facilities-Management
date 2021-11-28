import { Contractor } from "./contractor";
import { Note } from "./note";
import { PremisesAddress } from "./premisesAddress";
import { PremisesTask } from "./premisesTask";
import { PropAccountant } from "./propAccountant";

export interface Property {   
        id: string;
        premiseNumber?: any;
        premiseName: string;
        isDeleted: boolean;
        dateCreated: Date;
        phoneNumber1: string;
        phoneNumber2?: any;
        email: string;
        accountantId: string;
        premisesAddress: PremisesAddress;
        notes: Note[];
        premisesTasks: PremisesTask[];
        contractors: any[];
}

