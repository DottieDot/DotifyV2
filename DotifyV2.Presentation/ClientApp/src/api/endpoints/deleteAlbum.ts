import apiRequest from '../apiRequest'

export default async (albumId: number): Promise<boolean> => {
  const response = await apiRequest(`/api/albums/${albumId}`, 'DELETE')
  if (response.ok) {
    const result = await response.json() as boolean
    return !!result
  }
  return false
}
