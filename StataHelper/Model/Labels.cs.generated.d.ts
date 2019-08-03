declare module Server.Dtos {
	interface Labels {
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
			labels: Server.Dtos.Labels[];
		};
		varlabs: any[];
	}
}
