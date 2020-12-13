import { TableCell, TableRow } from '@material-ui/core'
import React from 'react'
import { ArtistDescritpion } from '../api/model'

interface Props {
  songNr: number
  name: string
  duration: number
  artist?: ArtistDescritpion
}

export default ({ songNr, name, duration, artist }: Props) => {
  return (
    <TableRow>
      <TableCell width="4ch">
        {songNr}
      </TableCell>
      <TableCell>
        {name}
      </TableCell>
      {artist && (
        <TableCell>
          {artist.name}
        </TableCell>
      )}
      <TableCell align="right">
        {Math.floor(duration / 60)}:{duration % 60}
      </TableCell>
    </TableRow>
  )
}
