export interface MigrationStep {
  title: string
  summary: string
}

const defaultSteps: MigrationStep[] = [
  {
    title: 'Audit Angular modules and dependencies',
    summary:
      'Capture the routes, feature modules, and shared services in the existing Angular app so they can be recreated with Vue Router and Pinia.',
  },
  {
    title: 'Stand up equivalent Vue routes',
    summary:
      'Rebuild the top-level navigation structure inside src/router/index.ts and back it with placeholder components for each migrated page.',
  },
  {
    title: 'Port shared services and API integrations',
    summary:
      'Translate Angular services into composables or Pinia stores that wrap the same ASP.NET endpoints used by the current client.',
  },
  {
    title: 'Replace Angular UI with Vue components',
    summary:
      'Move templates into <template> blocks, reuse the Composition API for logic, and carry across the styling system defined in the Angular project.',
  },
]

export function useMigrationSteps() {
  return { steps: defaultSteps }
}
