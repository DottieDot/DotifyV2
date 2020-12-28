
export default interface AuthenticatedUserResponse {
  id: number
  name: string
  likes: {
    songs: number[]
    albums: number[]
    artists: number[]
  }
}
