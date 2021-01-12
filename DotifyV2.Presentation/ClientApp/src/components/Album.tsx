import React, { useCallback } from 'react'
import { useHistory } from 'react-router'
import MediaCover from './MediaCover'
import MediaGridItem from './MediaGridItem'

interface Props {
  id: number
  name: string
  coverArt: string | null
}

export default ({ id, name, coverArt }: Props) => {
  const history = useHistory()

  const onClick = useCallback(() => {
    history.push(`/albums/${id}`)
  }, [history, id])

  return (
    <MediaGridItem name={name} onClick={onClick}>
      <MediaCover
        name={name}
        coverArt={coverArt}
      />
    </MediaGridItem>
  )
}
