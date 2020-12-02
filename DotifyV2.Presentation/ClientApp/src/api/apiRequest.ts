
let apiToken: string | undefined = undefined

export const setApiToken = (token: string | undefined) => apiToken = token

export default (route: string, body?: any, headers?: Record<string, string>) =>
  fetch(route, {
    body: (body !== undefined) ? JSON.stringify(body) : undefined,
    headers: {
      ...(apiToken ? { 'Authorization': `Bearer ${apiToken}` } : undefined),
      ...((body !== undefined) ? { 'Conten-Type': 'application/json' } : undefined),
      ...headers,
    }
  })
