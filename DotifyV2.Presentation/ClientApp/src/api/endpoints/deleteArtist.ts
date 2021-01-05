import apiRequest from '../apiRequest'

export default async (): Promise<boolean> => {
  const response = await apiRequest(`/api/artists`, 'DELETE')
  if (response.ok) {
    const result = await response.json() as boolean
    return !!result
  }
  return false
}
