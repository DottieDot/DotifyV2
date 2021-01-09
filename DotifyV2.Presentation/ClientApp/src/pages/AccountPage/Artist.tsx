import { Button, ButtonGroup } from '@material-ui/core'
import React, { Fragment, useCallback, useState } from 'react'
import { Link } from 'react-router-dom'
import { useAuthenticatedUser } from '../../hooks'
import DeleteArtistDialog from './DeleteArtistDialog'
import NewArtistDialog from './NewArtistDialog'

export default () => {
  const user = useAuthenticatedUser()
  const [newArtistDialog, setNewArtistDialog] = useState(false)
  const [deleteArtistDialog, setDeleteArtistDialog] = useState(false)

  const closeDeleteArtistDialog = useCallback(() => {
    setDeleteArtistDialog(false)
  }, [setDeleteArtistDialog])

  const onDeleteArtist = useCallback(() => {
    setDeleteArtistDialog(true)
  }, [setDeleteArtistDialog])

  const closeNewArtistDialog = useCallback(() => {
    setNewArtistDialog(false)
  }, [setNewArtistDialog])

  const onCreateArtist = useCallback(() => {
    setNewArtistDialog(true)
  }, [setNewArtistDialog])

  if (user?.artist_id) {
    return (
      <Fragment>
        <ButtonGroup
          color="primary"
          variant="contained"
          disableElevation
          fullWidth
        >
          <Button
            component={Link}
            to={`/artists/${user.artist_id}`}
            color="primary"
          >
            Artist Page
          </Button>
          <Button
            color="secondary"
            onClick={onDeleteArtist}
          >
            Delete Artist
          </Button>
        </ButtonGroup>
        <DeleteArtistDialog 
          open={deleteArtistDialog}
          onClose={closeDeleteArtistDialog}
        />
      </Fragment>
    )
  }
  else {
    return (
      <Fragment>
        <Button
          variant="contained"
          color="primary"
          onClick={onCreateArtist}
          fullWidth
        >
          Create Artist
        </Button>
        <NewArtistDialog
          open={newArtistDialog}
          onClose={closeNewArtistDialog}
        />
      </Fragment>
    )
  }
}
