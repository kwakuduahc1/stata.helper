export interface ILabColls {
  labelCollectionsID: number;
  labelName: string;
  description: string;
  concurrency: number[];
  labels: ILabels[];
}

export interface ILabels {
  labelsID: number;
  labelCollectionsID: number;
  key: number;
  label: string;
  concurrency: number[];
  varlabs: IVarlabs[];
}

export interface IProjects {
  projectsID: number;
  project: string;
  description: string;
  concurrency: number[];
  variables: IVarlabs[];
}

export interface IVariables {
  variablesID: number;
  variable: string;
  projectsID: number;
  description: string;
  concurrency: number[];
  varlabs: IVarlabs[];
}

export interface IVarlabs {
  varlabsID: number;
  variablesID: number;
  labelsID: number;
  concurrency: number[];
}

export interface ICommands {
  commandsID: number;
  command: string;
  projectsID: number;
  concurrency: number[];
}
