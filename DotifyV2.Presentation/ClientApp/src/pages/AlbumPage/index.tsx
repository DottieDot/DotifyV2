import { Container, Table, TableHead, TableRow, TableCell, TableBody } from '@material-ui/core'
import React, { Fragment, useEffect, useState } from 'react'
import { MediaAvatar, MediaPageAppBar } from '../../Components'

export default () => {
  const [album, setAlbum] = useState(null)

  useEffect(() => {

  }, [setAlbum])

  return (
    <Fragment>
      <MediaPageAppBar
        avatar={<MediaAvatar type="album" name={null} picture={null} />}
        title={null}
      />
      <Container fixed>
        <Table>
          <TableHead>
            <TableRow>
              <TableCell>#</TableCell>
              <TableCell>Name</TableCell>
              <TableCell align="right">Duration</TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            
          </TableBody>
        </Table>
      </Container>
    </Fragment>
  )
}

