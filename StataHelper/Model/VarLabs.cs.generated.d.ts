declare module Server.Dtos {
	interface Varlabs {
		varlabsID: number;
		variablesID: number;
		labelsID: number;
		labels: {
			labelsID: number;
			labelCollectionsID: number;
			key: any;
			label: string;
			concurrency: any[];
			labelCollections: {
				labelCollectionsID: number;
				labelName: string;
				description: string;
				concurrency: any[];
				labels: any[];
			};
			varlabs: Server.Dtos.Varlabs[];
		};
		variables: {
			variablesID: number;
			variable: string;
			projectsID: number;
			description: string;
			concurrency: any[];
			projects: {
				projectsID: number;
				project: string;
				description: string;
				concurrency: any[];
				variables: any[];
			};
			varlabs: Server.Dtos.Varlabs[];
		};
	}
}
