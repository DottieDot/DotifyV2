import { Container, Grid, makeStyles, Paper, Table, TableBody, TableCell, TableContainer, TableHead, TableRow } from '@material-ui/core'
import React, { Fragment, useRef } from 'react'
import { AppBar, MediaInfoCardSkeleton, SongTableRowSkeleton } from '../../components'

const useStyles = makeStyles(theme => ({
  stickyMediaInfroCardContainer: {
    position: 'sticky',
    top: 75
  },
  cardGridItem: {
    [theme.breakpoints.up('md')]: {
      maxWidth: 220
    }
  },
  buttonGroup: {
    marginBottom: theme.spacing(1),
    [theme.breakpoints.down('md')]: {
      marginTop: theme.spacing(1),
    }
  },
}))

export default () => {
  const classes = useStyles()
  const stickyMediaInfoCardContainer = useRef(null)

  return (
    <Fragment>
      <AppBar />
      <Container maxWidth="lg">
        <div
          className={classes.stickyMediaInfroCardContainer}
          ref={stickyMediaInfoCardContainer}
        />
        <Grid container spacing={2}>
          <Grid item className={classes.cardGridItem} md xs={12}>
            <MediaInfoCardSkeleton
              stickyContainer={stickyMediaInfoCardContainer}
              subtitle
              shareable
              playable
            />
          </Grid>
          <Grid item xs>
            <TableContainer component={Paper}>
              <Table>
                <TableHead>
                  <TableRow>
                    <TableCell width={30}>#</TableCell>
                    <TableCell>Name</TableCell>
                    <TableCell align="right" width={80}>Duration</TableCell>
                  </TableRow>
                </TableHead>
                <TableBody>
                  <SongTableRowSkeleton row={0} />
                  <SongTableRowSkeleton row={1} />
                  <SongTableRowSkeleton row={2} />
                </TableBody>
              </Table>
            </TableContainer>
          </Grid>
        </Grid>
      </Container>
    </Fragment>
  )
}
