import { Button, Dialog, DialogActions, DialogContent, DialogContentText, DialogTitle, TextField } from '@material-ui/core'
import React, { ChangeEvent, FormEvent, useCallback, useState } from 'react'
import { useDispatch } from 'react-redux'
import * as endpoints from '../../api/endpoints'
import { AlbumResponse } from '../../api/model'
import { showAlert } from '../../store/actions/Alerts'

interface Props {
  open: boolean
  onClose: (album: AlbumResponse | null) => void
}

export default ({ open, onClose }: Props) => {
  const [name, setName] = useState('')
  const [submitting, setSubmitting] = useState(false)
  const dispatch = useDispatch()

  const handleClose = useCallback(() => {
    if (!submitting) {
      onClose(null)
      setName('')
    }
  }, [submitting, onClose, setName])

  const onNameChange = useCallback((event: ChangeEvent<HTMLInputElement>) => {
    setName(event.target.value)
  }, [setName])

  const onSubmit = useCallback(async (event: FormEvent<HTMLFormElement>) => {
    event.preventDefault()
    setSubmitting(true)
    const album = await endpoints.createAlbum(name)
    if (album) {
      dispatch(showAlert('Created album', 'success'))
      setSubmitting(false)
      setName('')
      onClose(album)
    }
    else {
      dispatch(showAlert('Failed to create album', 'error'))
      setSubmitting(false)
    }
  }, [setSubmitting, name, dispatch, onClose])

  return (
    <Dialog open={open} onClose={handleClose}>
      <form onSubmit={onSubmit}>
        <DialogTitle>Create Album</DialogTitle>
        <DialogContent>
          <DialogContentText>
            Enter a name for the album.
          </DialogContentText>
          <TextField
            margin="dense"
            label="Name"
            type="text"
            value={name}
            onChange={onNameChange}
            disabled={submitting}
            required
            fullWidth
          />
        </DialogContent>
        <DialogActions>
          <Button
            disabled={submitting}
            onClick={handleClose}
            color="primary"
          >
            Cancel
          </Button>
          <Button
            disabled={!name.trim() || submitting}
            type="submit"
            color="primary"
          >
            Create
          </Button>
        </DialogActions>
      </form>
    </Dialog>
  )
}
