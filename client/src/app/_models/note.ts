export interface Note {
    id: string;
    noteContent: string;
    isPerm: boolean;
    isDeleted: boolean;
    dateCreated: Date;
    premisesId:string;
}
