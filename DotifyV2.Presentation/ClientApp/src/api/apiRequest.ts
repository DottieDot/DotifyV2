
let apiToken: string | undefined = undefined

export const setApiToken = (token: string | undefined) => apiToken = token

export default (route: string, method: string, body?: any, headers?: Record<string, string>) =>
  fetch(route, {
    body: (body !== undefined) ? JSON.stringify(body) : undefined,
    method: method,
    headers: {
      ...(apiToken ? { 'Authorization': `Bearer ${apiToken}` } : undefined),
      ...((body !== undefined) ? { 'Content-Type': 'application/json' } : undefined),
      ...headers,
    }
  })
