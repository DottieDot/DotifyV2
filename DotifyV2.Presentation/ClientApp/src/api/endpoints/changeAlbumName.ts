import apiRequest from '../apiRequest'

export default async (albumId: number, name: string): Promise<boolean> => {
  const response = await apiRequest(`/api/albums/${albumId}/name`, 'PATCH', {
      name
  })
  if (response.ok) {
    const result = await response.json() as boolean
    return !!result
  }
  return false
}
