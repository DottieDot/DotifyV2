import apiRequest from '../apiRequest'

export default async (songId: number): Promise<boolean> => {
  const response = await apiRequest(`/api/songs/${songId}`, 'DELETE')
  if (response.ok) {
    const result = await response.json() as boolean
    return !!result
  }
  return false
}
