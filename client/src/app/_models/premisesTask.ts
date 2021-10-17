export interface PremisesTask {
    id: string;
    title: string;
    description: string;
    completionDate: Date;
    noteId?: any;
    isDeleted: boolean;
    premisesId: number;
}
